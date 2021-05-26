using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BnE.EducationVest.API.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exam",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    exam_number = table.Column<int>(type: "integer", nullable: false),
                    exam_type = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    removed_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exam", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "incremented_text",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    increments = table.Column<string>(type: "json", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_incremented_text", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(250)", nullable: true),
                    subject_father_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    removed_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject", x => x.id);
                    table.ForeignKey(
                        name: "fk_subject_subject_subject_father_id",
                        column: x => x.subject_father_id,
                        principalTable: "subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "varchar(20)", nullable: true),
                    gender = table.Column<string>(type: "varchar(10)", nullable: true),
                    email = table.Column<string>(type: "varchar(320)", nullable: true),
                    birth_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    addresscep = table.Column<string>(name: "address.cep", type: "char(9)", nullable: true),
                    addressstreet = table.Column<string>(name: "address.street", type: "varchar(150)", nullable: true),
                    addressneighborhood = table.Column<string>(name: "address.neighborhood", type: "varchar(50)", nullable: true),
                    addresscity = table.Column<string>(name: "address.city", type: "char(50)", nullable: true),
                    addressstate = table.Column<string>(name: "address.state", type: "char(2)", nullable: true),
                    addressnumber = table.Column<string>(name: "address.number", type: "char(7)", nullable: true),
                    cognito_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_teacher = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    removed_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_menu",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(30)", nullable: true),
                    to_teacher = table.Column<bool>(type: "boolean", nullable: false),
                    to_student = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    removed_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_menu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exam_period",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    open_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    close_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    exam_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exam_period", x => x.id);
                    table.ForeignKey(
                        name: "fk_exam_period_exam_exam_id",
                        column: x => x.exam_id,
                        principalTable: "exam",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    exam_id = table.Column<Guid>(type: "uuid", nullable: false),
                    enunciated_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subject_id = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    removed_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question", x => x.id);
                    table.ForeignKey(
                        name: "fk_question_exam_exam_id",
                        column: x => x.exam_id,
                        principalTable: "exam",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_question_incremented_texts_enunciated_id",
                        column: x => x.enunciated_id,
                        principalTable: "incremented_text",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_question_subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alternative",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    text_content_id = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_alternative", x => x.id);
                    table.ForeignKey(
                        name: "fk_alternative_incremented_texts_text_content_id",
                        column: x => x.text_content_id,
                        principalTable: "incremented_text",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_alternative_question_question_id",
                        column: x => x.question_id,
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question_answers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    chosen_alternative_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    removed_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_answers", x => x.id);
                    table.ForeignKey(
                        name: "fk_question_answers_alternative_chosen_alternative_id",
                        column: x => x.chosen_alternative_id,
                        principalTable: "alternative",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_question_answers_question_question_id",
                        column: x => x.question_id,
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_question_answers_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "exam",
                columns: new[] { "id", "created_date", "exam_number", "exam_type", "removed_date", "updated_date" },
                values: new object[,]
                {
                    { new Guid("a0248834-cb91-47ad-8ebf-c297a43b83da"), new DateTime(2021, 5, 26, 4, 47, 30, 533, DateTimeKind.Local).AddTicks(9745), 1, 2, null, new DateTime(2021, 5, 26, 4, 47, 30, 533, DateTimeKind.Local).AddTicks(9754) },
                    { new Guid("68c0dc0e-b2a8-42d2-84ee-9bd67935442a"), new DateTime(2021, 5, 26, 4, 47, 30, 534, DateTimeKind.Local).AddTicks(3778), 1, 1, null, new DateTime(2021, 5, 26, 4, 47, 30, 534, DateTimeKind.Local).AddTicks(3780) },
                    { new Guid("974ec3e7-820e-4c93-8baa-9a0e6afe1869"), new DateTime(2021, 5, 26, 4, 47, 30, 534, DateTimeKind.Local).AddTicks(3788), 2, 1, null, new DateTime(2021, 5, 26, 4, 47, 30, 534, DateTimeKind.Local).AddTicks(3789) }
                });

            migrationBuilder.InsertData(
                table: "incremented_text",
                columns: new[] { "id", "content", "increments" },
                values: new object[,]
                {
                    { new Guid("b08eb7d1-8cf8-4b06-a01b-65e9cd549ada"), "60°", null },
                    { new Guid("aecc275b-1c3e-4cfa-abe3-289fd0165a3f"), "30°", null },
                    { new Guid("2d61858e-a017-4283-a515-efbb98e8056b"), "45°", null },
                    { new Guid("86677fe9-774d-416f-9c4c-005c83770952"), "22,5°", null },
                    { new Guid("da0d0b06-7631-4238-b8ff-4305e74e84ca"), "15°", null },
                    { new Guid("6aea269f-e6ec-4329-822a-eb7b88a5df85"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("37f7bff8-536e-4da7-a0c3-0b40a39ac24e"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("63fdf9d4-e821-4795-8e12-4721acd70c42"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("d192f6ae-1293-4a2e-b315-fe892b6e7fa9"), "menor do que 128.", null },
                    { new Guid("755a0284-e567-49c0-a355-5a84be5c0e4c"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("3af96568-7b31-49f4-814a-1f0740bb1a08"), "5,34", null },
                    { new Guid("58062c16-6c23-43a9-84c0-8d2569fdab6b"), "3,68", null },
                    { new Guid("93785566-68eb-4b4f-a789-dbe3ecc78a63"), "6.62", null },
                    { new Guid("92e2247b-308d-477e-aeaf-6fb2a54b5367"), "8,32", null },
                    { new Guid("90a56a33-e4c3-48dd-ac0c-d321d6db9dc9"), "4,64", null },
                    { new Guid("336179f6-7076-454e-9e2a-04c3290a598a"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("151328e0-b0f3-4b95-afc1-834c9808c1a7"), "entre 128 e 129.", null },
                    { new Guid("9526bf44-80c2-4caa-8a67-e8fe17ab0b8d"), "entre 129 e 130.", null },
                    { new Guid("c65c6d51-d7a7-48c7-8902-46ed67f30a0a"), "entre 130 e 131.", null },
                    { new Guid("b88c80fd-61b4-423a-9fbb-cb13d0eeb7f7"), "30°", null },
                    { new Guid("f501864c-b0de-451c-bdc9-2e1187d4409f"), "45°", null },
                    { new Guid("753cf316-3508-44b8-a0d5-65c361b7bd20"), "22,5°", null },
                    { new Guid("1c535693-8b38-4061-9c38-7270fa2b934c"), "15°", null },
                    { new Guid("488e500f-403b-4ff3-8f0e-7486e318479a"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("e5cf2b82-a953-445e-90df-87195cf5f56a"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("0f3bd82f-bb96-43c5-b497-3b295d7d1ce6"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("2a74bfc8-39d3-4073-8095-94ab266239fd"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("48263d81-a784-45fe-9eae-57e97cfa9c0b"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("3932a938-8dcf-45b1-84de-ffe18a95308f"), "5,34", null },
                    { new Guid("1cb574ec-2571-4daf-a662-5af9fe3f508b"), "3,68", null },
                    { new Guid("25fa0ca1-a3df-4078-aa6f-1709de7b8b51"), "6.62", null },
                    { new Guid("c203a24c-377c-412c-997a-21d4acb13924"), "8,32", null },
                    { new Guid("b5ac5cb2-8ddc-4e91-bb9f-fbc4b44bda23"), "4,64", null },
                    { new Guid("91c46238-0b3a-441f-8913-d63db690811e"), "maior que 131", null },
                    { new Guid("4922b1cf-4898-4334-8b13-fdde2d12bbb8"), "maior que 131", null },
                    { new Guid("67a63bd5-f566-44dc-adf6-393268c35b3e"), "entre 130 e 131.", null },
                    { new Guid("dcf71aaa-01f7-4db0-a45e-b15baef1c52e"), "entre 128 e 129.", null },
                    { new Guid("4af16ecd-c5e1-4e70-81de-942b39fe3ecb"), "60°", null },
                    { new Guid("a50c5b90-4796-4aae-96b8-bc4f810b8c7a"), "entre 128 e 129.", null },
                    { new Guid("ed803340-dcd7-4ef1-89df-0a463570de2a"), "menor do que 128.", null },
                    { new Guid("86e28e5a-e625-4a47-a0a0-c76f70401ff1"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("46c24ece-b49c-4dfa-8a7d-2a13c72f180d"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("c50c0197-63f5-4981-8bbe-9d5d6a15110c"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("2a40a266-9bdb-49e8-8d64-826e2c2ea7b3"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("41793612-5dad-4819-854a-8e9d7a258d55"), "entre 129 e 130.", null },
                    { new Guid("a5dd6bfc-9be5-497e-bd0b-845244fe11b8"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("3d814d32-d8c3-4588-b7f5-4eb076a23bc0"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("8733649f-56b9-4cbe-8573-d8036445afad"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("12d88cf6-24e6-4d54-957e-4e122e68223f"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("5ecc6019-2c21-4697-a6d8-ed2269b36804"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("858ee0e8-2bd9-4946-ac4f-b39a16bd2665"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("03039ee2-368c-461b-b886-21849f52403c"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("4d73cee0-128e-457d-9d8f-41e2aa53d848"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("4d4621be-ac40-49f4-88bb-05e2c697a48a"), "entre 129 e 130.", null },
                    { new Guid("dc35735c-1b52-4a3e-8702-d3df6e7423e3"), "entre 130 e 131.", null },
                    { new Guid("3ae998f6-35d1-4894-bce8-5adf5a4e6643"), "4,64", null },
                    { new Guid("98db651c-cca1-465c-a19c-c07fc7fe020b"), "menor do que 128.", null },
                    { new Guid("e613ebfd-b8e9-47ad-8c9c-03afd1765e49"), "60°", null },
                    { new Guid("cec2682c-05e0-46c8-86eb-c0fb91a0981e"), "30°", null },
                    { new Guid("58b4fff4-47c0-4a4a-b4ee-4363f2269a17"), "45°", null },
                    { new Guid("9d2b6aa5-1be8-4a0f-b938-585070b25c64"), "22,5°", null },
                    { new Guid("e7bd8893-6224-41cd-85b9-44da321b486a"), "15°", null },
                    { new Guid("c76fa30b-428a-4990-a201-8e8362507f2f"), "maior que 131", null },
                    { new Guid("886c768a-8979-45c3-af8e-44fbf7177b3f"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("a0912b7a-1b6f-4e2f-9986-c90cc16d03ea"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("4a33e538-7c62-4ae7-8162-334b37c0e257"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("b061ac1f-fd15-4230-a90e-4586f70e3c35"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("a9145e8c-4d77-4860-a7d5-2bc46770ec67"), "5,34", null },
                    { new Guid("bce6f353-79d2-4a45-bd69-3e9b628dcd3b"), "3,68", null },
                    { new Guid("a5b036ff-4400-4ad4-aba0-e3769d160ccc"), "6.62", null },
                    { new Guid("06bc6e27-e8cc-489f-b938-ce4a62daf32e"), "8,32", null },
                    { new Guid("b5fa6980-ca54-4632-bcd0-7aceba3efe2b"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("4347dd12-7802-4daa-a0ec-3363d615783e"), new DateTime(2021, 5, 26, 4, 47, 30, 524, DateTimeKind.Local).AddTicks(7005), "Português", null, null, new DateTime(2021, 5, 26, 4, 47, 30, 524, DateTimeKind.Local).AddTicks(7009) },
                    { new Guid("8a53f376-b123-42aa-a454-9d8eb53a8912"), new DateTime(2021, 5, 26, 4, 47, 30, 524, DateTimeKind.Local).AddTicks(5682), "Matemática", null, null, new DateTime(2021, 5, 26, 4, 47, 30, 524, DateTimeKind.Local).AddTicks(6143) }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "birth_date", "cognito_user_id", "created_date", "email", "gender", "is_teacher", "name", "phone_number", "removed_date", "updated_date", "address.cep", "address.city", "address.neighborhood", "address.number", "address.state", "address.street" },
                values: new object[] { new Guid("cef7157f-38f0-4b0d-bf04-bcce3550a40d"), new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e32ca6c-2a66-4ea6-a0c4-cf655dab5191"), new DateTime(2021, 5, 26, 4, 47, 30, 533, DateTimeKind.Local).AddTicks(2612), "sacchitiellogiovanni@gmail.com", "Masculino", false, "Giovanni Sacchitiello", "11991392711", null, new DateTime(2021, 5, 26, 4, 47, 30, 533, DateTimeKind.Local).AddTicks(2628), "03320020", "São Paulo", "Carrão", "148", "SP", "Rua antonio ciucio" });

            migrationBuilder.InsertData(
                table: "exam_period",
                columns: new[] { "id", "close_date", "exam_id", "open_date" },
                values: new object[,]
                {
                    { new Guid("4a1eaa66-ada9-4627-8023-5ceebb22d3d1"), new DateTime(2021, 5, 30, 12, 0, 0, 0, DateTimeKind.Local), new Guid("a0248834-cb91-47ad-8ebf-c297a43b83da"), new DateTime(2021, 5, 30, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("6ea4cf99-2fb3-414b-89d2-c19c9b07a3e5"), new DateTime(2021, 5, 31, 12, 0, 0, 0, DateTimeKind.Local), new Guid("a0248834-cb91-47ad-8ebf-c297a43b83da"), new DateTime(2021, 5, 31, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("a3c9550d-da20-4294-96ff-8ba923a42061"), new DateTime(2021, 5, 26, 8, 47, 30, 534, DateTimeKind.Local).AddTicks(3746), new Guid("68c0dc0e-b2a8-42d2-84ee-9bd67935442a"), new DateTime(2021, 5, 26, 4, 47, 30, 534, DateTimeKind.Local).AddTicks(3746) },
                    { new Guid("fdb2dd59-500e-4abc-8cd8-dcc2e33b3dd5"), new DateTime(2021, 5, 27, 6, 47, 30, 534, DateTimeKind.Local).AddTicks(3746), new Guid("68c0dc0e-b2a8-42d2-84ee-9bd67935442a"), new DateTime(2021, 5, 27, 4, 47, 30, 534, DateTimeKind.Local).AddTicks(3746) },
                    { new Guid("fd6e2189-0a6b-44f8-a406-f7b3783d6b33"), new DateTime(2021, 5, 24, 6, 47, 30, 534, DateTimeKind.Local).AddTicks(3783), new Guid("974ec3e7-820e-4c93-8baa-9a0e6afe1869"), new DateTime(2021, 5, 24, 4, 47, 30, 534, DateTimeKind.Local).AddTicks(3783) },
                    { new Guid("cc84b322-6282-4462-a357-d56509c92fda"), new DateTime(2021, 5, 25, 6, 47, 30, 534, DateTimeKind.Local).AddTicks(3783), new Guid("974ec3e7-820e-4c93-8baa-9a0e6afe1869"), new DateTime(2021, 5, 25, 4, 47, 30, 534, DateTimeKind.Local).AddTicks(3783) }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("e7653b46-303a-4f29-853a-171852129c6b"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(6259), new Guid("03039ee2-368c-461b-b886-21849f52403c"), new Guid("a0248834-cb91-47ad-8ebf-c297a43b83da"), 0, null, new Guid("8a53f376-b123-42aa-a454-9d8eb53a8912"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(6265) },
                    { new Guid("5385fcaa-3d87-4e6e-a003-7c4a9b3ff496"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(8880), new Guid("5ecc6019-2c21-4697-a6d8-ed2269b36804"), new Guid("a0248834-cb91-47ad-8ebf-c297a43b83da"), 2, null, new Guid("4347dd12-7802-4daa-a0ec-3363d615783e"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(8881) },
                    { new Guid("d689513c-4d22-41fb-9f46-f1c0ee889978"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(8959), new Guid("8733649f-56b9-4cbe-8573-d8036445afad"), new Guid("68c0dc0e-b2a8-42d2-84ee-9bd67935442a"), 0, null, new Guid("8a53f376-b123-42aa-a454-9d8eb53a8912"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(8961) },
                    { new Guid("b8cf34cc-aa69-45a2-9c7a-63f1e8734145"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(8989), new Guid("4d73cee0-128e-457d-9d8f-41e2aa53d848"), new Guid("68c0dc0e-b2a8-42d2-84ee-9bd67935442a"), 2, null, new Guid("4347dd12-7802-4daa-a0ec-3363d615783e"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(8990) },
                    { new Guid("e1d785ad-339f-494e-8bd3-3020db419aaf"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(9017), new Guid("2a40a266-9bdb-49e8-8d64-826e2c2ea7b3"), new Guid("974ec3e7-820e-4c93-8baa-9a0e6afe1869"), 0, null, new Guid("8a53f376-b123-42aa-a454-9d8eb53a8912"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(9018) },
                    { new Guid("217a3067-4d5f-45d7-ad35-678eb9b0367c"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(9045), new Guid("46c24ece-b49c-4dfa-8a7d-2a13c72f180d"), new Guid("974ec3e7-820e-4c93-8baa-9a0e6afe1869"), 2, null, new Guid("4347dd12-7802-4daa-a0ec-3363d615783e"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(9046) }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[] { new Guid("8bcfe5bd-5fb1-4098-8792-af2109fb5829"), new DateTime(2021, 5, 26, 4, 47, 30, 524, DateTimeKind.Local).AddTicks(7012), "Porcentagem", null, new Guid("8a53f376-b123-42aa-a454-9d8eb53a8912"), new DateTime(2021, 5, 26, 4, 47, 30, 524, DateTimeKind.Local).AddTicks(7013) });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("44fa41bc-be85-4546-85a5-e01e22d212bf"), 1, false, new Guid("d689513c-4d22-41fb-9f46-f1c0ee889978"), new Guid("dcf71aaa-01f7-4db0-a45e-b15baef1c52e") },
                    { new Guid("b9df44ff-b58d-46e5-88a2-85d55cc0fca0"), 4, false, new Guid("d689513c-4d22-41fb-9f46-f1c0ee889978"), new Guid("4922b1cf-4898-4334-8b13-fdde2d12bbb8") },
                    { new Guid("85c052a9-de87-4009-9e4b-fd82a68fedac"), 0, true, new Guid("b8cf34cc-aa69-45a2-9c7a-63f1e8734145"), new Guid("755a0284-e567-49c0-a355-5a84be5c0e4c") },
                    { new Guid("8d1432c4-221a-4a6b-9f5f-a7b4a700de0a"), 1, false, new Guid("b8cf34cc-aa69-45a2-9c7a-63f1e8734145"), new Guid("63fdf9d4-e821-4795-8e12-4721acd70c42") },
                    { new Guid("50d9124b-9fdc-4675-8d19-76b3be05a620"), 2, false, new Guid("b8cf34cc-aa69-45a2-9c7a-63f1e8734145"), new Guid("336179f6-7076-454e-9e2a-04c3290a598a") },
                    { new Guid("a30f143f-fdd8-4215-a7ba-e2be6ef67cc0"), 3, false, new Guid("b8cf34cc-aa69-45a2-9c7a-63f1e8734145"), new Guid("37f7bff8-536e-4da7-a0c3-0b40a39ac24e") },
                    { new Guid("e5abc012-5be8-4820-be44-482b5bca0934"), 4, false, new Guid("b8cf34cc-aa69-45a2-9c7a-63f1e8734145"), new Guid("6aea269f-e6ec-4329-822a-eb7b88a5df85") },
                    { new Guid("1dd8b922-7eb4-4280-b83f-bcdf6e864df4"), 3, false, new Guid("d689513c-4d22-41fb-9f46-f1c0ee889978"), new Guid("67a63bd5-f566-44dc-adf6-393268c35b3e") },
                    { new Guid("2a924617-b363-411f-be82-3800d067600e"), 0, true, new Guid("e1d785ad-339f-494e-8bd3-3020db419aaf"), new Guid("d192f6ae-1293-4a2e-b315-fe892b6e7fa9") },
                    { new Guid("4e0b7f13-0961-48ec-97ba-0ae654de2b74"), 2, false, new Guid("e1d785ad-339f-494e-8bd3-3020db419aaf"), new Guid("9526bf44-80c2-4caa-8a67-e8fe17ab0b8d") },
                    { new Guid("11508755-d3d2-460b-9599-01aefdfd45e2"), 3, false, new Guid("e1d785ad-339f-494e-8bd3-3020db419aaf"), new Guid("c65c6d51-d7a7-48c7-8902-46ed67f30a0a") },
                    { new Guid("34a3e089-4f99-40b9-9c31-bbc605a9a95a"), 4, false, new Guid("e1d785ad-339f-494e-8bd3-3020db419aaf"), new Guid("91c46238-0b3a-441f-8913-d63db690811e") },
                    { new Guid("257d72a3-becd-47d3-a8d0-49445c3e8fed"), 0, true, new Guid("217a3067-4d5f-45d7-ad35-678eb9b0367c"), new Guid("48263d81-a784-45fe-9eae-57e97cfa9c0b") },
                    { new Guid("170b66b7-b45d-4053-8a8b-c2446fd92683"), 1, false, new Guid("217a3067-4d5f-45d7-ad35-678eb9b0367c"), new Guid("2a74bfc8-39d3-4073-8095-94ab266239fd") },
                    { new Guid("139eb1aa-eacf-4c8e-8927-fe8de5b755fb"), 2, false, new Guid("217a3067-4d5f-45d7-ad35-678eb9b0367c"), new Guid("0f3bd82f-bb96-43c5-b497-3b295d7d1ce6") },
                    { new Guid("ea87b757-5aa6-45f2-b0b7-4157573da16d"), 1, false, new Guid("e1d785ad-339f-494e-8bd3-3020db419aaf"), new Guid("151328e0-b0f3-4b95-afc1-834c9808c1a7") },
                    { new Guid("fab94f10-c99b-47b9-8fcf-5ba1d43f04aa"), 2, false, new Guid("d689513c-4d22-41fb-9f46-f1c0ee889978"), new Guid("4d4621be-ac40-49f4-88bb-05e2c697a48a") },
                    { new Guid("64185bbc-4975-426b-91f3-27a7ccd428be"), 4, false, new Guid("217a3067-4d5f-45d7-ad35-678eb9b0367c"), new Guid("488e500f-403b-4ff3-8f0e-7486e318479a") },
                    { new Guid("d36697b8-f28e-4b8c-9f1c-0016ee69a443"), 0, true, new Guid("d689513c-4d22-41fb-9f46-f1c0ee889978"), new Guid("98db651c-cca1-465c-a19c-c07fc7fe020b") },
                    { new Guid("2af36916-41df-4f08-b204-619b1ec8a29a"), 0, true, new Guid("e7653b46-303a-4f29-853a-171852129c6b"), new Guid("ed803340-dcd7-4ef1-89df-0a463570de2a") },
                    { new Guid("2b6464e0-9c0c-4a01-9031-1d5b43f9d2ec"), 1, false, new Guid("e7653b46-303a-4f29-853a-171852129c6b"), new Guid("a50c5b90-4796-4aae-96b8-bc4f810b8c7a") },
                    { new Guid("f986b5b0-d075-45ef-a795-19b33f252b54"), 3, false, new Guid("217a3067-4d5f-45d7-ad35-678eb9b0367c"), new Guid("e5cf2b82-a953-445e-90df-87195cf5f56a") },
                    { new Guid("c601d2fe-5f77-4ac2-9088-3701dfc25cb0"), 3, false, new Guid("e7653b46-303a-4f29-853a-171852129c6b"), new Guid("dc35735c-1b52-4a3e-8702-d3df6e7423e3") },
                    { new Guid("83efbed7-6e5c-449b-8f58-7be243f0ab66"), 4, false, new Guid("e7653b46-303a-4f29-853a-171852129c6b"), new Guid("c76fa30b-428a-4990-a201-8e8362507f2f") },
                    { new Guid("9208c0a9-5de9-4437-8bff-30068dd40059"), 2, false, new Guid("e7653b46-303a-4f29-853a-171852129c6b"), new Guid("41793612-5dad-4819-854a-8e9d7a258d55") },
                    { new Guid("e34409dc-af44-4de3-9d65-249d78523a0b"), 1, false, new Guid("5385fcaa-3d87-4e6e-a003-7c4a9b3ff496"), new Guid("4a33e538-7c62-4ae7-8162-334b37c0e257") },
                    { new Guid("5802337e-542c-4faa-93f9-f150a18cfcfe"), 2, false, new Guid("5385fcaa-3d87-4e6e-a003-7c4a9b3ff496"), new Guid("a0912b7a-1b6f-4e2f-9986-c90cc16d03ea") },
                    { new Guid("489a5e2a-c09b-47c1-98a8-b18e63777018"), 3, false, new Guid("5385fcaa-3d87-4e6e-a003-7c4a9b3ff496"), new Guid("b5fa6980-ca54-4632-bcd0-7aceba3efe2b") },
                    { new Guid("c82075de-71e6-4234-9fb7-2531d57844f4"), 4, false, new Guid("5385fcaa-3d87-4e6e-a003-7c4a9b3ff496"), new Guid("886c768a-8979-45c3-af8e-44fbf7177b3f") },
                    { new Guid("eabd9a41-4963-4ad9-918b-e59e237564f9"), 0, true, new Guid("5385fcaa-3d87-4e6e-a003-7c4a9b3ff496"), new Guid("b061ac1f-fd15-4230-a90e-4586f70e3c35") }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("d0264f1a-051a-4704-ae6d-c6b8c5f7a04a"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(9091), new Guid("86e28e5a-e625-4a47-a0a0-c76f70401ff1"), new Guid("974ec3e7-820e-4c93-8baa-9a0e6afe1869"), 3, null, new Guid("8bcfe5bd-5fb1-4098-8792-af2109fb5829"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(9092) },
                    { new Guid("29bb9c83-fb13-4883-9995-e701f4d05fb5"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(9030), new Guid("c50c0197-63f5-4981-8bbe-9d5d6a15110c"), new Guid("974ec3e7-820e-4c93-8baa-9a0e6afe1869"), 1, null, new Guid("8bcfe5bd-5fb1-4098-8792-af2109fb5829"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(9031) },
                    { new Guid("193f5127-3df9-4abe-a1db-e90cb99d9467"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(9002), new Guid("a5dd6bfc-9be5-497e-bd0b-845244fe11b8"), new Guid("68c0dc0e-b2a8-42d2-84ee-9bd67935442a"), 3, null, new Guid("8bcfe5bd-5fb1-4098-8792-af2109fb5829"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(9003) },
                    { new Guid("2482ff14-c029-4cbb-a8b3-e8ace94b6e85"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(8975), new Guid("3d814d32-d8c3-4588-b7f5-4eb076a23bc0"), new Guid("68c0dc0e-b2a8-42d2-84ee-9bd67935442a"), 1, null, new Guid("8bcfe5bd-5fb1-4098-8792-af2109fb5829"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(8976) },
                    { new Guid("1b954b4d-0733-4ab8-b85a-79532d12b1fb"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(8894), new Guid("12d88cf6-24e6-4d54-957e-4e122e68223f"), new Guid("a0248834-cb91-47ad-8ebf-c297a43b83da"), 3, null, new Guid("8bcfe5bd-5fb1-4098-8792-af2109fb5829"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(8894) },
                    { new Guid("0244bb6c-4ae0-43d5-a630-5eb07c843ed7"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(8857), new Guid("858ee0e8-2bd9-4946-ac4f-b39a16bd2665"), new Guid("a0248834-cb91-47ad-8ebf-c297a43b83da"), 1, null, new Guid("8bcfe5bd-5fb1-4098-8792-af2109fb5829"), new DateTime(2021, 5, 26, 4, 47, 30, 525, DateTimeKind.Local).AddTicks(8862) }
                });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("6b18a709-5096-46da-9716-eef86340be65"), 0, true, new Guid("0244bb6c-4ae0-43d5-a630-5eb07c843ed7"), new Guid("3ae998f6-35d1-4894-bce8-5adf5a4e6643") },
                    { new Guid("439830a9-e2ab-410e-a669-ddf87f95fd6e"), 4, false, new Guid("d0264f1a-051a-4704-ae6d-c6b8c5f7a04a"), new Guid("4af16ecd-c5e1-4e70-81de-942b39fe3ecb") },
                    { new Guid("5b764eb0-63b1-4596-8634-98d88022b8ac"), 3, false, new Guid("d0264f1a-051a-4704-ae6d-c6b8c5f7a04a"), new Guid("b88c80fd-61b4-423a-9fbb-cb13d0eeb7f7") },
                    { new Guid("3c9fbff0-06d3-4318-8c07-cc5ae4dd3b54"), 2, false, new Guid("d0264f1a-051a-4704-ae6d-c6b8c5f7a04a"), new Guid("f501864c-b0de-451c-bdc9-2e1187d4409f") },
                    { new Guid("915e630c-fc1d-44e7-a1bb-9d2e107322bb"), 1, false, new Guid("d0264f1a-051a-4704-ae6d-c6b8c5f7a04a"), new Guid("753cf316-3508-44b8-a0d5-65c361b7bd20") },
                    { new Guid("9a6b22b2-3a8f-4c77-be97-91dc390bb1c0"), 0, true, new Guid("d0264f1a-051a-4704-ae6d-c6b8c5f7a04a"), new Guid("1c535693-8b38-4061-9c38-7270fa2b934c") },
                    { new Guid("c72b8e6b-f561-407c-9570-941b707b728b"), 4, false, new Guid("29bb9c83-fb13-4883-9995-e701f4d05fb5"), new Guid("3932a938-8dcf-45b1-84de-ffe18a95308f") },
                    { new Guid("ab68a6a8-1df1-43f8-bd09-6f6dd58ff897"), 3, false, new Guid("29bb9c83-fb13-4883-9995-e701f4d05fb5"), new Guid("1cb574ec-2571-4daf-a662-5af9fe3f508b") },
                    { new Guid("856ee462-65a9-46fa-a5ea-e8bcaa95c342"), 2, false, new Guid("29bb9c83-fb13-4883-9995-e701f4d05fb5"), new Guid("25fa0ca1-a3df-4078-aa6f-1709de7b8b51") },
                    { new Guid("68afb253-a774-4005-b57f-709be9d04529"), 1, false, new Guid("29bb9c83-fb13-4883-9995-e701f4d05fb5"), new Guid("c203a24c-377c-412c-997a-21d4acb13924") },
                    { new Guid("4e856ff0-4690-4629-a49c-8a38a355ac63"), 0, true, new Guid("29bb9c83-fb13-4883-9995-e701f4d05fb5"), new Guid("b5ac5cb2-8ddc-4e91-bb9f-fbc4b44bda23") },
                    { new Guid("55eca8fd-fec9-40f4-a6a9-61503facfc9a"), 4, false, new Guid("193f5127-3df9-4abe-a1db-e90cb99d9467"), new Guid("b08eb7d1-8cf8-4b06-a01b-65e9cd549ada") },
                    { new Guid("fb34cd67-27a1-4ff4-8603-c0dc7189c96c"), 3, false, new Guid("193f5127-3df9-4abe-a1db-e90cb99d9467"), new Guid("aecc275b-1c3e-4cfa-abe3-289fd0165a3f") },
                    { new Guid("a7300e0e-0151-4c88-8f87-4450296d069e"), 2, false, new Guid("193f5127-3df9-4abe-a1db-e90cb99d9467"), new Guid("2d61858e-a017-4283-a515-efbb98e8056b") },
                    { new Guid("29e440f0-91bd-4645-9648-ffe9b93c17d6"), 1, false, new Guid("193f5127-3df9-4abe-a1db-e90cb99d9467"), new Guid("86677fe9-774d-416f-9c4c-005c83770952") },
                    { new Guid("68d3f6b8-d290-4565-8dce-4b3d797a8523"), 0, true, new Guid("193f5127-3df9-4abe-a1db-e90cb99d9467"), new Guid("da0d0b06-7631-4238-b8ff-4305e74e84ca") },
                    { new Guid("eb958ec6-e498-43bd-b544-420fbe1fc8da"), 4, false, new Guid("2482ff14-c029-4cbb-a8b3-e8ace94b6e85"), new Guid("3af96568-7b31-49f4-814a-1f0740bb1a08") },
                    { new Guid("90d2884f-89fc-4842-a04e-53094163c168"), 3, false, new Guid("2482ff14-c029-4cbb-a8b3-e8ace94b6e85"), new Guid("58062c16-6c23-43a9-84c0-8d2569fdab6b") },
                    { new Guid("cad3541a-9f1d-4451-9f66-cbfcb807d4f6"), 2, false, new Guid("2482ff14-c029-4cbb-a8b3-e8ace94b6e85"), new Guid("93785566-68eb-4b4f-a789-dbe3ecc78a63") },
                    { new Guid("0bf93ac5-e670-4b3a-b08e-3bb001e8a13b"), 1, false, new Guid("2482ff14-c029-4cbb-a8b3-e8ace94b6e85"), new Guid("92e2247b-308d-477e-aeaf-6fb2a54b5367") },
                    { new Guid("db92431a-4f15-46b1-806c-c335008a73cf"), 0, true, new Guid("2482ff14-c029-4cbb-a8b3-e8ace94b6e85"), new Guid("90a56a33-e4c3-48dd-ac0c-d321d6db9dc9") },
                    { new Guid("bc03cecb-b139-4707-842b-7eb72a751e51"), 4, false, new Guid("1b954b4d-0733-4ab8-b85a-79532d12b1fb"), new Guid("e613ebfd-b8e9-47ad-8c9c-03afd1765e49") },
                    { new Guid("b6bed543-db4c-49cd-9ac5-2c1d33348f66"), 3, false, new Guid("1b954b4d-0733-4ab8-b85a-79532d12b1fb"), new Guid("cec2682c-05e0-46c8-86eb-c0fb91a0981e") },
                    { new Guid("319c775e-dfc5-4318-aae5-800da6e24d7a"), 2, false, new Guid("1b954b4d-0733-4ab8-b85a-79532d12b1fb"), new Guid("58b4fff4-47c0-4a4a-b4ee-4363f2269a17") },
                    { new Guid("341e47e3-9070-4dbd-aae7-8555ef1f1608"), 1, false, new Guid("1b954b4d-0733-4ab8-b85a-79532d12b1fb"), new Guid("9d2b6aa5-1be8-4a0f-b938-585070b25c64") },
                    { new Guid("be031634-dabb-4d9e-ab8d-b3f1347a9fd6"), 0, true, new Guid("1b954b4d-0733-4ab8-b85a-79532d12b1fb"), new Guid("e7bd8893-6224-41cd-85b9-44da321b486a") },
                    { new Guid("3fb4c4c5-965a-45c6-8c0f-fb5b20ede240"), 4, false, new Guid("0244bb6c-4ae0-43d5-a630-5eb07c843ed7"), new Guid("a9145e8c-4d77-4860-a7d5-2bc46770ec67") },
                    { new Guid("1337e8e8-1c54-4190-aae9-e9da56138bbb"), 3, false, new Guid("0244bb6c-4ae0-43d5-a630-5eb07c843ed7"), new Guid("bce6f353-79d2-4a45-bd69-3e9b628dcd3b") },
                    { new Guid("ffdc195e-1f1e-4093-88f3-e021221b86f2"), 2, false, new Guid("0244bb6c-4ae0-43d5-a630-5eb07c843ed7"), new Guid("a5b036ff-4400-4ad4-aba0-e3769d160ccc") },
                    { new Guid("11a8fad6-d4e5-4086-bd90-60613942daaa"), 1, false, new Guid("0244bb6c-4ae0-43d5-a630-5eb07c843ed7"), new Guid("06bc6e27-e8cc-489f-b938-ce4a62daf32e") }
                });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[,]
                {
                    { new Guid("55dbab28-495c-4499-bb50-94046be16040"), new Guid("d36697b8-f28e-4b8c-9f1c-0016ee69a443"), new DateTime(2021, 5, 26, 4, 47, 30, 541, DateTimeKind.Local).AddTicks(7061), new Guid("d689513c-4d22-41fb-9f46-f1c0ee889978"), null, new DateTime(2021, 5, 26, 4, 47, 30, 541, DateTimeKind.Local).AddTicks(7076), new Guid("cef7157f-38f0-4b0d-bf04-bcce3550a40d") },
                    { new Guid("e7a0aef5-1a18-4ae6-b034-5b868a23a339"), new Guid("85c052a9-de87-4009-9e4b-fd82a68fedac"), new DateTime(2021, 5, 26, 4, 47, 30, 541, DateTimeKind.Local).AddTicks(8501), new Guid("b8cf34cc-aa69-45a2-9c7a-63f1e8734145"), null, new DateTime(2021, 5, 26, 4, 47, 30, 541, DateTimeKind.Local).AddTicks(8502), new Guid("cef7157f-38f0-4b0d-bf04-bcce3550a40d") }
                });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[,]
                {
                    { new Guid("7593c84d-dd6c-4249-b468-127f1ced893f"), new Guid("db92431a-4f15-46b1-806c-c335008a73cf"), new DateTime(2021, 5, 26, 4, 47, 30, 541, DateTimeKind.Local).AddTicks(8480), new Guid("2482ff14-c029-4cbb-a8b3-e8ace94b6e85"), null, new DateTime(2021, 5, 26, 4, 47, 30, 541, DateTimeKind.Local).AddTicks(8486), new Guid("cef7157f-38f0-4b0d-bf04-bcce3550a40d") },
                    { new Guid("715b8acc-e7f2-4fd5-87c0-0b917bb73968"), new Guid("68d3f6b8-d290-4565-8dce-4b3d797a8523"), new DateTime(2021, 5, 26, 4, 47, 30, 541, DateTimeKind.Local).AddTicks(8505), new Guid("193f5127-3df9-4abe-a1db-e90cb99d9467"), null, new DateTime(2021, 5, 26, 4, 47, 30, 541, DateTimeKind.Local).AddTicks(8506), new Guid("cef7157f-38f0-4b0d-bf04-bcce3550a40d") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_alternative_question_id",
                table: "alternative",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "ix_alternative_text_content_id",
                table: "alternative",
                column: "text_content_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_exam_period_exam_id",
                table: "exam_period",
                column: "exam_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_enunciated_id",
                table: "question",
                column: "enunciated_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_question_exam_id",
                table: "question",
                column: "exam_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_subject_id",
                table: "question",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_answers_chosen_alternative_id",
                table: "question_answers",
                column: "chosen_alternative_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_answers_question_id",
                table: "question_answers",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_answers_user_id",
                table: "question_answers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_subject_father_id",
                table: "subject",
                column: "subject_father_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_cognito_user_id",
                table: "user",
                column: "cognito_user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exam_period");

            migrationBuilder.DropTable(
                name: "question_answers");

            migrationBuilder.DropTable(
                name: "user_menu");

            migrationBuilder.DropTable(
                name: "alternative");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "exam");

            migrationBuilder.DropTable(
                name: "incremented_text");

            migrationBuilder.DropTable(
                name: "subject");
        }
    }
}
