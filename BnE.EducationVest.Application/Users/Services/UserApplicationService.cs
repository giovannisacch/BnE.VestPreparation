using BnE.EducationVest.Application.Users.Interface;
using BnE.EducationVest.Application.Users.ViewModels;
using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Users.Interfaces.InfraService;
using BnE.EducationVest.Domain.Users.Entities;
using System.Threading.Tasks;
using BnE.EducationVest.Domain.Users.ValueObjects;
using BnE.EducationVest.Domain.Users.Interfaces.InfraData;
using Microsoft.AspNetCore.Http;
using BnE.EducationVest.Application.Common.Extensions;
using System.Linq;
using System.Net;
using System;
using BnE.EducationVest.Application.Exams.ViewModels.Request;
using BnE.EducationVest.Domain.Users.Interfaces;
using System.Collections.Generic;
using BnE.EducationVest.Domain;
using System.IO;
using System.Threading;
using System.ComponentModel;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace BnE.EducationVest.Application.Users.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserAuthService _userAuthService;
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _userDomainService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserApplicationService(IUserAuthService userAuthService, IUserRepository userRepository,
                                      IHttpContextAccessor httpContextAccessor, IUserDomainService userDomainService)
        {
            _userAuthService = userAuthService;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _userDomainService = userDomainService;
        }
        public async Task DeleteUser()
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var user = await _userRepository.GetUserByCognitoId(Guid.Parse(tokenData.CognitoId));
            await _userAuthService.RemoveUserAsync(tokenData.UserName);
            await _userRepository.DeleteAsync(user);
        }
        public async Task<Either<ErrorResponseModel, Guid>> AddUserAsync(CreateUserRequestModel createUserRequestModel)
        {
            //Adicionar no banco de dados
            //Criar mapper
            var addressVO = new AddressVO(createUserRequestModel.Address.CEP, createUserRequestModel.Address.Street,
                                           createUserRequestModel.Address.Neighborhood, createUserRequestModel.Address.City,
                                           createUserRequestModel.Address.State);
            var user = new User(createUserRequestModel.Name, createUserRequestModel.CPF, 
                                createUserRequestModel.PhoneNumber, createUserRequestModel.Gender, createUserRequestModel.Email, 
                                createUserRequestModel.BirthDate, addressVO, createUserRequestModel.UserType);
            await _userAuthService.CreateUserAsync(user);
            await _userRepository.AddAsync(user);
            return new Either<ErrorResponseModel, Guid>(user.Id, HttpStatusCode.OK);
        }

        public async Task<Either<ErrorResponseModel, object>> ChangePasswordAsAdmin(FirstPasswordChangeRequestModel firstPasswordChangeRequestModel)
        {
            return await _userAuthService
                .AdminUpdateUserPasswordAsync(firstPasswordChangeRequestModel.Username, 
                                              firstPasswordChangeRequestModel.Password, firstPasswordChangeRequestModel.OldPassword);

            //Atualizar propriedade active no banco e dados
        }

        public async Task<Either<ErrorResponseModel, object>> ConfirmPasswordRecover(string username, string code, string newPassword)
        {
            
            return await _userAuthService.ConfirmPasswordRecover(username, code, newPassword);
        }

        public async Task<Either<ErrorResponseModel, object>> InitiateRecoverPassword(string username)
        {
            var user = await _userRepository.GetUserByEmail(username);
            if (user == null)
                return new Either<ErrorResponseModel, object>(new ErrorResponseModel(ErrorConstants.USER_NOT_FOUND), HttpStatusCode.BadRequest);
            return await _userAuthService.SendForgotPasswordCodeAsync(username, user.Name);
        }

        public async Task<Either<ErrorResponseModel, object>> LoginAsync(LoginRequestModel loginRequestModel)
        {
            if (loginRequestModel.LoginFlow == ELoginFlow.Credentials)
                return await _userAuthService.LoginAsync(loginRequestModel.Username, loginRequestModel.Password);
            else
                return await _userAuthService.LoginRefreshTokenAsync(loginRequestModel.RefreshToken);
        }
        public async Task<Either<ErrorResponseModel, UserMenusViewModel>> GetUserMenu()
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var groups = tokenData.CognitoGroups.ToList();
            //TODO: Refatorar forma de verificar grupos, está altamente acoplado com a nomenclatura do cognito
            var menus = await _userRepository.GetAvailableMenusByUserGroup(groups.Contains("Teachers"), (groups.Contains("Students") || groups.Contains("ExternalStudents")) );
            var user = await _userRepository.GetUserByCognitoId(Guid.Parse(tokenData.CognitoId));

            return new Either<ErrorResponseModel, UserMenusViewModel>(new UserMenusViewModel() { 
                                                                                                    Name = user.Name, 
                                                                                                    BirthDate = user.BirthDate, 
                                                                                                    TermsWasAccepted = user.WasAcceptedTerms,
                                                                                                    ImageUrl = "https://pic.onlinewebfonts.com/svg/img_561160.png",
                                                                                                    Menus = menus.Select(x => new MenuViewModel() 
                                                                                                    {
                                                                                                        Key = x.Key, Label = x.Label, Selected = (x.Key == "current_exams") ? true : false 
                                                                                                    }) 
                                                                                                }, HttpStatusCode.OK);
        }

        public async Task<Either<ErrorResponseModel, object>> AddExternalUserProfile(ExternalUserProfileRequestViewModel externalUserProfileRequestView)
        {
            var externalUserProfileDOmain = new ExternalUserProfile()
            {
                ExpectedCollege = externalUserProfileRequestView.ExpectedCollege,
                ExpectedCourse = externalUserProfileRequestView.ExpectedCourse,
                ActualCollege = externalUserProfileRequestView.ActualCollege,
                ActualOccupation = externalUserProfileRequestView.ActualOccupation,
                UserId = externalUserProfileRequestView.UserId
            };
            await _userRepository.AddExternalUserProfile(externalUserProfileDOmain);
            return new Either<ErrorResponseModel, object>(new {id = externalUserProfileDOmain.Id}, HttpStatusCode.OK);
        }

        public async Task AcceptUserTerms()
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var user = await _userRepository.GetUserByCognitoId(Guid.Parse(tokenData.CognitoId));
            user.AcceptTerms();
            await _userRepository.UpdateAsync(user);
        }
        public async Task UpdateUserOptins(UpdateUserOptinRequestViewModel updateUserOptinRequestViewModel)
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            var userWithOptIns = await _userRepository.GetUserWithOptinsByIdAsync(userId);
            //Removendo os optins que não estão vindo marcados nessa API
            userWithOptIns.Optins.RemoveAll(x => !updateUserOptinRequestViewModel.CheckedOptIns.Contains(x.OptinId));
            var optinsToAdd = updateUserOptinRequestViewModel.CheckedOptIns.Where(x => !userWithOptIns.Optins.Any(opt => opt.OptinId == x)).ToList();
            optinsToAdd.ForEach(x => userWithOptIns.AddAcceptedOptin(x));
            await _userRepository.UpdateAsync(userWithOptIns);
        }
        public async Task<TermAndOptinResponseViewModel> GetUseTermAndOptins()
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            var optinsWithUserAccept = await _userRepository.GetOptinsAndUserAccepts(userId);
            return new TermAndOptinResponseViewModel()
            {
                Text = @"TERMOS DE USO  
Informações: O presente documento tem por finalidade lhe informar sobre o uso desta plataforma. Para maiores informações sobre o tratamento de seus dados, gentileza consultar nossa política de privacidade. 
Os serviços desenvolvidos na plataforma são fornecidos pela pessoa jurídica B&E Assessoria Ltda, inscrita no CNPJ sob o n° 37.980.963/0001-09, e-mail tecnologia@bneassessoria.com, telefone (11) 99139-2711, com sede na Rua Gomes de Carvalho, n° 1.765, 8° andar, Vila Olímpia, São Paulo (SP), CEP 04.547-901. 
Finalidade: A plataforma tem por objetivo permitir que o usuário cadastrado realize testes e provas para avaliar seu desempenho educacional, assim como visa permitir que os professores acompanhem o desempenho e a evolução do usuário. 
Aceitação: Este documento estabelece obrigações contratadas de livre e espontânea vontade, por tempo indeterminado, entre a plataforma e você (usuário). Ao utilizar a plataforma, você aceita integralmente as presentes normas e se compromete a observá-las. A aceitação deste instrumento é imprescindível para o acesso e para a utilização de quaisquer serviços fornecidos pela plataforma. Caso você não concorde com as disposições deste documento, não deve utilizar a plataforma. 
Acesso: Serão utilizadas todas as soluções técnicas à disposição do responsável pela plataforma para permitir o acesso ininterrupto aos seus serviços. Entretanto, a navegação no website ou em algumas de suas páginas poderá ser interrompida, limitada ou suspensa para atualizações, modificações ou qualquer ação necessária ao seu bom funcionamento. 
Cadastro: O acesso às funcionalidades da plataforma dependerá de cadastro prévio pelo usuário.

Os alunos regulares serão cadastrados automaticamente pelos responsáveis pela plataforma de acordo com os dados informados pelo próprio aluno em sua ficha de matrícula.
Usuários externos, não matriculados, poderão ser convidados para testar ou utilizar a plataforma. Para tanto, em seu primeiro acesso, o usuário externo deve informar o código disponibilizado pela B&E e preencher seus dados para que seja cadastrado na plataforma.
O cadastro do professor será realizado nos mesmos moldes do aluno regular: pelo backoffice da B&E, mediante a informação dos dados pelo professor.
O usuário deverá se cadastrar com dados completos, recentes e válidos, sendo de sua exclusiva responsabilidade manter os referidos dados atualizados, bem como o usuário se compromete com a veracidade dos dados fornecidos. 
A B&E se reserva no direito de conferir os dados informados pelo usuário, podendo solicitar dados e/ou documentos adicionais.
O usuário se compromete a não informar seus dados de acesso à plataforma para terceiros, responsabilizando-se integralmente pelo uso que deles seja feito. Cabe unicamente ao usuário a segurança de sua senha e manutenção de sua confidencialidade.
O usuário aceita e compromete-se a notificar imediatamente a B&E tão logo tenha conhecimento da perda, do roubo, da apropriação indevida ou da utilização não autorizada dos seus dados de acesso à plataforma. A B&E pode suspender a utilização dos dados de acesso do usuário caso suspeite que a segurança destes foi comprometida ou que ocorreu qualquer utilização fraudulenta ou não autorizada.
O acesso do usuário poderá ser cancelado/inativado quando este deixar de ser aluno da B&E.
Menores de 18 anos ou aqueles que não possuírem plena capacidade civil deverão obter previamente o consentimento expresso de seus responsáveis legais para a utilização da plataforma, sendo destes últimos a exclusiva responsabilidade pelo eventual acesso daqueles. 
Mediante a realização do cadastro/acesso, o usuário declara e garante expressamente ser plenamente capaz, podendo exercer e usufruir livremente dos serviços e produtos. 
O usuário deverá fornecer endereço de e-mail válido no campo cadastral, por meio do qual a plataforma poderá realizar as comunicações necessárias. 
Não é permitido ceder, vender, alugar ou transferir, de qualquer forma, a conta ou os dados de acesso, visto que são pessoais e intransferíveis. 
Cabe ao usuário assegurar que seu equipamento seja compatível com as características técnicas que viabilizem a utilização da plataforma. 
O usuário, ao aceitar os termos de uso, autoriza expressamente o tratamento de seus dados, nos termos indicados na política de privacidade.

Suporte: Em caso de qualquer dúvida, sugestão ou problema com a utilização da plataforma, o usuário poderá entrar em contato com o suporte por meio do e-mail institucional@bneassessoria.com. 
Responsabilidades: 

a) É de responsabilidade do usuário: 
a.1) defeitos ou vícios técnicos originados em seu próprio sistema; 
a.2) a correta utilização da plataforma, dos serviços ou produtos oferecidos, prezando pela boa convivência, pelo respeito e cordialidade entre os usuários; 
a.3) pelo cumprimento e respeito ao conjunto de regras disposto nesse Termos de Uso, na Política de Privacidade e na legislação nacional e internacional; 
a.4) pela proteção aos dados de acesso à sua conta. 

Além das listadas acima, também é de responsabilidade do professor inserir, revisar e disponibilizar na plataforma os conteúdos e atividades.


b) A B&E:
b.1) não será responsável, em nenhuma hipótese, por quaisquer danos indiretos, de qualquer natureza, que possam ser atribuíveis ao uso ou à incapacidade de uso da plataforma ou qualquer conteúdo nela publicado. Também não será responsável pelo sucesso ou insucesso do usuário nas provas que realizar, nem por qualquer operação ou relacionamento entre usuários.
b.2) não poderá ser responsabilizada por quaisquer danos morais e materiais diretos, indiretos, incidentais, especiais, consequenciais ou punitivos que não tenham sido causados direta e imediatamente pela plataforma ou por seus funcionários, incluindo, mas não se limitando a perdas e danos, lucros cessantes, perda de uma chance, outras perdas e danos intangíveis, relacionados ou não ao uso da plataforma.
b.3) não se responsabiliza por links externos contidos em sua plataforma que possam redirecionar o usuário à ambientes externos à sua rede. 
b.4) poderá, mas não tem a obrigação de monitorar, analisar ou editar o conteúdo dos usuários. Em todos os casos, a B&E se reserva ao direito de remover ou desabilitar o acesso a qualquer conteúdo por qualquer motivo, principalmente os que violem os presentes Termos. A remoção ou desabilitação poderá ser feita sem qualquer aviso prévio.
Direitos autorais: O presente documento concede aos usuários uma licença não exclusiva, não transferível e não sublicenciável, para acessar e fazer uso da plataforma e dos serviços e produtos por ela disponibilizados. Não há cessão a transferência ao usuário de qualquer direito, de modo que o acesso não gera qualquer direito de propriedade intelectual a ele. 
A estrutura do website, as marcas, logotipos, nomes comerciais, layouts gráficos e design de interface, imagens, ilustrações, fotografias, apresentações, vídeos, conteúdos escritos e de  som e áudio, programas de computador, bancos de dados, arquivos de transmissão e  quaisquer outras informações e direitos de propriedade intelectual da B&E estão devidamente  reservados, nos termos da Lei de Propriedade Industrial (Lei n° 9.279/96), Lei de Direitos  Autorais (Lei n° 9.610/98), Lei de Software (Lei n° 9.609/98) e demais normas aplicáveis. 
O uso da plataforma pelo usuário é pessoal, individual e intransferível, sendo vedado qualquer uso não autorizado (cópia, reprodução ou alteração),  comercial ou não-comercial. Tais usos consistirão em violações dos direitos de propriedade intelectual da B&E, puníveis nos termos da legislação aplicável.

Sanções: Sem prejuízo das demais medidas legais cabíveis, a B&E poderá a qualquer momento advertir, suspender ou cancelar o acesso do usuário que: 
a) violar qualquer dispositivo do presente Termo; 
b) descumprir os seus deveres de usuário; 
c) tiver qualquer comportamento fraudulento, doloso ou que ofenda a terceiros. 
Rescisão: A não observância das obrigações pactuadas neste Termos de Uso ou da legislação aplicável poderá, sem aviso prévio, ensejar a imediata rescisão unilateral por parte da B&E e o bloqueio de todos os serviços prestados ao usuário. 
Alterações: Os itens descritos no presente instrumento poderão sofrer alterações, unilateralmente e a qualquer tempo, por parte da B&E, para adequar ou modificar os serviços, bem como para atender novas exigências legais. As alterações serão veiculadas pela plataforma e o usuário poderá optar por aceitar o novo conteúdo ou por cancelar o uso dos serviços. 
Os serviços oferecidos podem, a qualquer momento e unilateralmente, sem qualquer aviso prévio, deixarem de ser fornecidos, alterados em suas características, bem como restringidos para uso e acesso. 
O usuário concorda que a B&E poderá transferir ou ceder sua posição contratual nestes Termos de Uso ou qualquer direito ou obrigação deles decorrente a qualquer tempo, sem a necessidade de prévio aviso ao usuário ou seu consentimento, inclusive em razão de operações societárias tais como, mais não se limitando a fusões, aquisições e reestruturações.
Foro: Para a solução de dúvidas e controvérsias oriundas da navegação no presente website, será aplicado integralmente o Direito brasileiro, devendo eventuais litígios serem levados ao foro da comarca de São Paulo (SP). 
Uso da plataforma: 
a) Para acessar a plataforma, o usuário deve informar seu e-mail cadastrado e o código disponibilizado pela B&E. Em seu primeiro acesso, o usuário deve definir a sua senha.
b) Em seu primeiro acesso, o usuário poderá optar por receber e-mails promocionais pela B&E e/ou e-mails informando novos simulados disponíveis. Essas opções poderão ser alteradas posteriormente na plataforma.
c) Na tela inicial após o acesso à plataforma, ao clicar em seu nome e foto disponíveis no canto superior esquerdo da tela, o usuário terá acesso aos seus dados cadastrados (nome completo, CPF e data de nascimento). Estes dados cadastrais não poderão ser alterados. Neste campo, o usuário também poderá revisitar os termos e políticas da plataforma.
d) Na plataforma, o usuário terá acesso às atividades e simulados a serem realizados, bem como à sua evolução e desempenho individual.
e) Na plataforma, o professor terá acesso à criação de simulados e atividades, bem como aos relatórios e evolução individual e coletiva dos usuários. 
f) Todas as informações relacionadas ao uso dos dados do usuário podem ser consultadas na política de privacidade da plataforma.

Disposições adicionais: Na eventualidade de qualquer disposição destes Termos ser considerada inválida ou inexequível, por qualquer motivo, esta não deve afetar ou tornar inválidas ou inexequíveis as disposições restantes.

As comunicações com o usuário serão realizadas pelo seu e-mail cadastrado, motivo pelo qual o usuário se compromete a mantê-lo sempre atualizado.

Quaisquer modificações entrarão em vigor a partir de sua publicação na plataforma, ou a partir da data indicada no ato.

Qualquer novo recurso que aprimore o serviço atual, bem como a disponibilização de novas ferramentas e recursos, estará sujeito a estes Termos.
",
                Optins = optinsWithUserAccept
                        .Select(x => new OptinResponseViewModel() { Id = x.Id, Text = x.Text, Checked = x.UsersAccepted == null? false : x.UsersAccepted.Any() })
                        .ToList()
            };
        }

        public async Task<Either<ErrorResponseModel, object>> CreateUsersBuk(IFormFile file)
        {
            if (file == null)
            {
                return new Either<ErrorResponseModel, object>(
                new ErrorResponseModel("Não contém arquivos para processamento, por favor verifique !!!"), HttpStatusCode.BadRequest);
            }

            if (!Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return new Either<ErrorResponseModel, object>(
                new ErrorResponseModel("O arquivo não contem o formato esperado, por favor verifique !!!"), HttpStatusCode.BadRequest);
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream, new CancellationToken());

                await ReadRowsFromFileAsync(stream);
            };


            return new Either<ErrorResponseModel, object>(new ErrorResponseModel(""), HttpStatusCode.OK);

        }
        private async Task ReadRowsFromFileAsync(MemoryStream stream)
        {
            

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                var worksheetFirst = package.Workbook.Worksheets.First();

                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {
                    var name = worksheet.Cells[row, 1].Value.ToString().Trim();
                    var cpf = "99999999941";
                    var phoneNumber = "+5511999999999";
                    var gender = "N/A";
                    var email = worksheet.Cells[row, 2].Value.ToString().Trim();
                    var addressVO = new AddressVO("13571-410", "R. Gomes de Carvalho, 1765",
                       "Vila Olímpia - Itaim Bibi", "São Paulo",
                       "SP");
                    var user = new User(name, cpf, phoneNumber, gender, email, DateTime.Parse("2000/01/01"), addressVO, Domain.Users.Enums.EUserType.InternalStudent);

                    await _userAuthService.CreateUserAsync(user);
                    await _userRepository.AddAsync(user);
                }
            }
        }
    }
}
