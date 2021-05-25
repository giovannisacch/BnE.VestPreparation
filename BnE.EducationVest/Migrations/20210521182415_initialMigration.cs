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
                    adresscity = table.Column<string>(name: "adress.city", type: "char(50)", nullable: true),
                    adressstate = table.Column<string>(name: "adress.state", type: "char(2)", nullable: true),
                    address_number = table.Column<string>(type: "text", nullable: true),
                    cognito_user_id = table.Column<string>(type: "text", nullable: true),
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
                    { new Guid("ba96b5ff-2e7f-4cfd-af1b-02a2acb6a9d4"), new DateTime(2021, 5, 21, 15, 24, 14, 275, DateTimeKind.Local).AddTicks(4397), 1, 2, null, new DateTime(2021, 5, 21, 15, 24, 14, 275, DateTimeKind.Local).AddTicks(4403) },
                    { new Guid("c10e97cc-550c-46b6-b5a5-c7f0063b67e5"), new DateTime(2021, 5, 21, 15, 24, 14, 275, DateTimeKind.Local).AddTicks(8181), 1, 1, null, new DateTime(2021, 5, 21, 15, 24, 14, 275, DateTimeKind.Local).AddTicks(8183) },
                    { new Guid("3cc64121-cd15-4a44-864a-9dddf34dd129"), new DateTime(2021, 5, 21, 15, 24, 14, 275, DateTimeKind.Local).AddTicks(8190), 2, 1, null, new DateTime(2021, 5, 21, 15, 24, 14, 275, DateTimeKind.Local).AddTicks(8191) }
                });

            migrationBuilder.InsertData(
                table: "incremented_text",
                columns: new[] { "id", "content", "increments" },
                values: new object[,]
                {
                    { new Guid("e44b1f61-90eb-44ad-b6ff-84dc2d1eca0c"), "60°", null },
                    { new Guid("dc8c32e3-1174-495a-b9fa-5ee4959adbce"), "30°", null },
                    { new Guid("2578e1c4-adbc-48c4-a349-e0c626bf9d36"), "45°", null },
                    { new Guid("ca77f135-5a90-4793-81aa-6e17fbb4e8c3"), "22,5°", null },
                    { new Guid("863e9fba-4869-4855-835b-90cd254b7f7c"), "15°", null },
                    { new Guid("0a49b696-f5ae-44b2-b8ce-30a81d381e3c"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("6a36a531-6ac3-433a-b368-49f97d5e8179"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("d67e12ab-94f7-46b6-abc6-ea887dcafa4e"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("387b1481-c070-44b5-80ef-dafabffd66ac"), "menor do que 128.", null },
                    { new Guid("98b62ddb-11fc-486b-916c-8da5834c6c1c"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("8aee8ea8-70bd-4424-bdef-9f306af121f9"), "5,34", null },
                    { new Guid("b1d4f086-1231-4eae-9280-82505e245256"), "3,68", null },
                    { new Guid("1f453586-7302-4b67-8cc8-062324114408"), "6.62", null },
                    { new Guid("f0496687-42aa-42a1-ac7e-a6c76ee44426"), "8,32", null },
                    { new Guid("97639e4b-7a86-453b-9e92-5c318ec1d2c7"), "4,64", null },
                    { new Guid("6e595aca-d6fa-45aa-954b-a2b9ab6b7c24"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("ea08de75-de76-43a5-a900-26fa7bdb3a8b"), "entre 128 e 129.", null },
                    { new Guid("0228672e-978f-42b3-b298-fba5e67f2c2f"), "entre 129 e 130.", null },
                    { new Guid("ee26a392-bf2b-4869-8e33-9e3b5748cb99"), "entre 130 e 131.", null },
                    { new Guid("ebbe4589-c510-4438-ad21-97bf684908b6"), "30°", null },
                    { new Guid("1d80f186-7d01-4dfe-b91e-087b537e6d39"), "45°", null },
                    { new Guid("736b4453-6b1e-4c5a-a455-5c88e47ae5aa"), "22,5°", null },
                    { new Guid("469e5ed2-2e70-4790-83ad-9af4ef75790f"), "15°", null },
                    { new Guid("31791314-91b2-4394-ab92-6be438829445"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("01e86d51-bb0d-458d-8a8b-0add58b661ac"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("08678161-87ad-4ae7-9cd8-21edec558246"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("945ac710-77fd-49e8-b80f-13261e33c115"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("bb17d6cb-5d13-4c6f-b441-3ca6e2e3bc71"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("bb09dde0-da40-400b-a8b8-5f61c74fdc2b"), "5,34", null },
                    { new Guid("c3333419-3209-4d26-9101-812807039a42"), "3,68", null },
                    { new Guid("37785e1d-fcb0-4113-bdac-99ef7b56f90c"), "6.62", null },
                    { new Guid("c2b02592-56a4-4bdc-8a1d-d61c4040b245"), "8,32", null },
                    { new Guid("d3bb5e76-ee66-4714-ae84-47b2f1d95f71"), "4,64", null },
                    { new Guid("a22a7551-a513-4039-b5dc-9dbe179c7e61"), "maior que 131", null },
                    { new Guid("c5153cc4-f304-480c-b0f8-acd8752daeef"), "maior que 131", null },
                    { new Guid("bcb3e2df-0c79-4a3b-933c-1a18098d0d6d"), "entre 130 e 131.", null },
                    { new Guid("1a0b07b7-b789-45be-a7cd-2581848cdd69"), "entre 128 e 129.", null },
                    { new Guid("f778b369-dfd4-49fb-a0af-ef18fac23de1"), "60°", null },
                    { new Guid("579136da-f046-4af1-a80d-a7542e9fc3d2"), "entre 128 e 129.", null },
                    { new Guid("e40be5ba-4f26-4c8c-bef7-24cfdedfb4f0"), "menor do que 128.", null },
                    { new Guid("6f855e6c-8e7d-4e35-a7df-9dcf8e1905a4"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("d50bc897-cc29-4623-9c06-b700f967d51b"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("f41835f2-27fa-4b8c-940b-d057d3dace31"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("1d1bdad8-8938-4404-acf7-f080c93d5595"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("4a43647e-c993-47f6-b2f8-155f26c95839"), "entre 129 e 130.", null },
                    { new Guid("63b05fea-2e37-4ed1-aa24-b1427f25d7f6"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("c6594c46-d221-4b52-97c7-6fac7528e471"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("b7e4daa1-412c-44fb-b74b-ec65c715be03"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("4bd84d0f-99bd-4897-b607-d789da24955e"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("2f62a39c-f197-468a-9760-42901fbb85d8"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("7de5adda-d4ef-46da-840b-01dbed82b7a0"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("b933168e-415f-401f-b894-7e3ef6e7db85"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("bd59de4f-689a-4e28-9c40-e06ad836c188"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("d08512a2-d3de-4108-9bad-4277df054b37"), "entre 129 e 130.", null },
                    { new Guid("076380e8-0379-42b3-934d-766b5e7d7707"), "entre 130 e 131.", null },
                    { new Guid("c3516ebc-0c19-4862-8f8a-81e12d5680d5"), "4,64", null },
                    { new Guid("c4aeff11-fe3d-4bcc-b590-aa80a1996b4e"), "menor do que 128.", null },
                    { new Guid("2ccc210b-a607-45f2-96d9-b60ec1929fe6"), "60°", null },
                    { new Guid("704664e2-12b4-42c8-9c4e-82ec7eac0449"), "30°", null },
                    { new Guid("2650d896-bcf6-4608-89bd-18c8c43f9ac9"), "45°", null },
                    { new Guid("b5ee87ea-6f83-448c-a7dc-6720a01060a2"), "22,5°", null },
                    { new Guid("ffd0bff3-40e4-443f-a625-9cb329fd5b40"), "15°", null },
                    { new Guid("a33fa429-ead0-4b61-b3e7-153a355f392d"), "maior que 131", null },
                    { new Guid("f8979a3b-2962-41a2-bb2c-b1fd5dc4c2bd"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("8ace563b-1e49-4810-9dc5-e2a1bf92c62c"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("b05ecef6-95b2-4fac-8e63-c7ed0b7edf73"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("3ba280f0-1929-4a52-abed-aab0dd020205"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("e117147d-7ff8-4bf3-8534-db1819fecec9"), "5,34", null },
                    { new Guid("aba3c46d-6a71-4dfe-a967-e09b7612cc31"), "3,68", null },
                    { new Guid("a77855c9-01b7-4f5a-a93e-f0fe677c258f"), "6.62", null },
                    { new Guid("96bef00d-efb0-4531-a8d1-fb04e34a6b45"), "8,32", null },
                    { new Guid("6d491ecb-9333-4031-b89e-733d3e7b4cd3"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("c9e43c59-b2ca-4102-89d6-d703e016706b"), new DateTime(2021, 5, 21, 15, 24, 14, 267, DateTimeKind.Local).AddTicks(4892), "Português", null, null, new DateTime(2021, 5, 21, 15, 24, 14, 267, DateTimeKind.Local).AddTicks(4896) },
                    { new Guid("13784a54-2b68-4143-870f-d0003bf6f6c3"), new DateTime(2021, 5, 21, 15, 24, 14, 267, DateTimeKind.Local).AddTicks(3639), "Matemática", null, null, new DateTime(2021, 5, 21, 15, 24, 14, 267, DateTimeKind.Local).AddTicks(4077) }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "birth_date", "cognito_user_id", "created_date", "email", "gender", "is_teacher", "name", "phone_number", "removed_date", "updated_date", "address.cep", "adress.city", "address.neighborhood", "address_number", "adress.state", "address.street" },
                values: new object[] { new Guid("d574be54-0eab-448d-8169-7da2367e7ffb"), new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "6e32ca6c-2a66-4ea6-a0c4-cf655dab5191", new DateTime(2021, 5, 21, 15, 24, 14, 274, DateTimeKind.Local).AddTicks(8043), "sacchitiellogiovanni@gmail.com", "Masculino", false, "Giovanni Sacchitiello", "11991392711", null, new DateTime(2021, 5, 21, 15, 24, 14, 274, DateTimeKind.Local).AddTicks(8050), "03320020", "São Paulo", "Carrão", "148", "SP", "Rua antonio ciucio" });

            migrationBuilder.InsertData(
                table: "exam_period",
                columns: new[] { "id", "close_date", "exam_id", "open_date" },
                values: new object[,]
                {
                    { new Guid("379ed9d1-e01b-4a65-a82f-9f883d64ec45"), new DateTime(2021, 5, 25, 12, 0, 0, 0, DateTimeKind.Local), new Guid("ba96b5ff-2e7f-4cfd-af1b-02a2acb6a9d4"), new DateTime(2021, 5, 25, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("4338699b-b33f-4cf5-9881-7fbb90ea349a"), new DateTime(2021, 5, 26, 12, 0, 0, 0, DateTimeKind.Local), new Guid("ba96b5ff-2e7f-4cfd-af1b-02a2acb6a9d4"), new DateTime(2021, 5, 26, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("72e119c6-667d-4750-93ff-b821e5edca0a"), new DateTime(2021, 5, 21, 19, 24, 14, 275, DateTimeKind.Local).AddTicks(8155), new Guid("c10e97cc-550c-46b6-b5a5-c7f0063b67e5"), new DateTime(2021, 5, 21, 15, 24, 14, 275, DateTimeKind.Local).AddTicks(8155) },
                    { new Guid("c0946bca-f4be-40d9-acff-9868165479bc"), new DateTime(2021, 5, 22, 17, 24, 14, 275, DateTimeKind.Local).AddTicks(8155), new Guid("c10e97cc-550c-46b6-b5a5-c7f0063b67e5"), new DateTime(2021, 5, 22, 15, 24, 14, 275, DateTimeKind.Local).AddTicks(8155) },
                    { new Guid("864e9d66-d257-4a05-90d6-2e3688977362"), new DateTime(2021, 5, 19, 17, 24, 14, 275, DateTimeKind.Local).AddTicks(8186), new Guid("3cc64121-cd15-4a44-864a-9dddf34dd129"), new DateTime(2021, 5, 19, 15, 24, 14, 275, DateTimeKind.Local).AddTicks(8186) },
                    { new Guid("5d7ec88e-30bb-4427-9791-4d9f4d4ea868"), new DateTime(2021, 5, 20, 17, 24, 14, 275, DateTimeKind.Local).AddTicks(8186), new Guid("3cc64121-cd15-4a44-864a-9dddf34dd129"), new DateTime(2021, 5, 20, 15, 24, 14, 275, DateTimeKind.Local).AddTicks(8186) }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("bb2aefce-f382-4a61-a1fa-083520bcb101"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(3554), new Guid("b933168e-415f-401f-b894-7e3ef6e7db85"), new Guid("ba96b5ff-2e7f-4cfd-af1b-02a2acb6a9d4"), 0, null, new Guid("13784a54-2b68-4143-870f-d0003bf6f6c3"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(3559) },
                    { new Guid("2c5cb800-9d91-448d-85c8-dbcdaa5ed4b6"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6026), new Guid("2f62a39c-f197-468a-9760-42901fbb85d8"), new Guid("ba96b5ff-2e7f-4cfd-af1b-02a2acb6a9d4"), 2, null, new Guid("c9e43c59-b2ca-4102-89d6-d703e016706b"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6027) },
                    { new Guid("234ec727-daf0-4d6e-afe9-09052d5eb10f"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6052), new Guid("b7e4daa1-412c-44fb-b74b-ec65c715be03"), new Guid("c10e97cc-550c-46b6-b5a5-c7f0063b67e5"), 0, null, new Guid("13784a54-2b68-4143-870f-d0003bf6f6c3"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6053) },
                    { new Guid("7e3dbc1e-07b2-4ec9-ab9e-392a352ae06c"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6122), new Guid("bd59de4f-689a-4e28-9c40-e06ad836c188"), new Guid("c10e97cc-550c-46b6-b5a5-c7f0063b67e5"), 2, null, new Guid("c9e43c59-b2ca-4102-89d6-d703e016706b"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6123) },
                    { new Guid("80f72574-d373-43f9-896f-0db71b80cccd"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6148), new Guid("1d1bdad8-8938-4404-acf7-f080c93d5595"), new Guid("3cc64121-cd15-4a44-864a-9dddf34dd129"), 0, null, new Guid("13784a54-2b68-4143-870f-d0003bf6f6c3"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6149) },
                    { new Guid("4e52de80-11bc-4ce3-9eba-59102dbb6e06"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6176), new Guid("d50bc897-cc29-4623-9c06-b700f967d51b"), new Guid("3cc64121-cd15-4a44-864a-9dddf34dd129"), 2, null, new Guid("c9e43c59-b2ca-4102-89d6-d703e016706b"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6177) }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[] { new Guid("42f2161c-d9a5-4612-91c0-c33406f9c5d1"), new DateTime(2021, 5, 21, 15, 24, 14, 267, DateTimeKind.Local).AddTicks(4898), "Porcentagem", null, new Guid("13784a54-2b68-4143-870f-d0003bf6f6c3"), new DateTime(2021, 5, 21, 15, 24, 14, 267, DateTimeKind.Local).AddTicks(4899) });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("9bd8b7c8-79ea-498b-a5d3-d4f306cfbe4d"), 1, false, new Guid("234ec727-daf0-4d6e-afe9-09052d5eb10f"), new Guid("1a0b07b7-b789-45be-a7cd-2581848cdd69") },
                    { new Guid("8c288fdb-e0d7-40f6-beb3-5981c6eb3738"), 4, false, new Guid("234ec727-daf0-4d6e-afe9-09052d5eb10f"), new Guid("c5153cc4-f304-480c-b0f8-acd8752daeef") },
                    { new Guid("86a98de2-681e-4ee3-9187-d7fb4fa0cd79"), 0, true, new Guid("7e3dbc1e-07b2-4ec9-ab9e-392a352ae06c"), new Guid("98b62ddb-11fc-486b-916c-8da5834c6c1c") },
                    { new Guid("d01c91e7-217e-42e8-ba6b-c7a7b38b3fa3"), 1, false, new Guid("7e3dbc1e-07b2-4ec9-ab9e-392a352ae06c"), new Guid("d67e12ab-94f7-46b6-abc6-ea887dcafa4e") },
                    { new Guid("6ed6a032-09f5-478b-8137-499371251401"), 2, false, new Guid("7e3dbc1e-07b2-4ec9-ab9e-392a352ae06c"), new Guid("6e595aca-d6fa-45aa-954b-a2b9ab6b7c24") },
                    { new Guid("57ebf51c-a29b-4512-9a32-bfc893727f65"), 3, false, new Guid("7e3dbc1e-07b2-4ec9-ab9e-392a352ae06c"), new Guid("6a36a531-6ac3-433a-b368-49f97d5e8179") },
                    { new Guid("9c3ea0e5-d8a0-46cb-bf93-2af43655f8ce"), 4, false, new Guid("7e3dbc1e-07b2-4ec9-ab9e-392a352ae06c"), new Guid("0a49b696-f5ae-44b2-b8ce-30a81d381e3c") },
                    { new Guid("7cae2a91-1519-43fe-8ddd-4470472a4813"), 3, false, new Guid("234ec727-daf0-4d6e-afe9-09052d5eb10f"), new Guid("bcb3e2df-0c79-4a3b-933c-1a18098d0d6d") },
                    { new Guid("41038f5d-fa16-46dc-88fd-acc6aa3a5f5c"), 0, true, new Guid("80f72574-d373-43f9-896f-0db71b80cccd"), new Guid("387b1481-c070-44b5-80ef-dafabffd66ac") },
                    { new Guid("0712fea4-33db-429a-bd53-74f0e99b3a3a"), 2, false, new Guid("80f72574-d373-43f9-896f-0db71b80cccd"), new Guid("0228672e-978f-42b3-b298-fba5e67f2c2f") },
                    { new Guid("1b133997-da41-4022-848a-a312324b19cf"), 3, false, new Guid("80f72574-d373-43f9-896f-0db71b80cccd"), new Guid("ee26a392-bf2b-4869-8e33-9e3b5748cb99") },
                    { new Guid("aefc9487-bb30-4e00-a90f-72e302b20c04"), 4, false, new Guid("80f72574-d373-43f9-896f-0db71b80cccd"), new Guid("a22a7551-a513-4039-b5dc-9dbe179c7e61") },
                    { new Guid("692498d6-1c5a-4946-9d97-cafd82e4074b"), 0, true, new Guid("4e52de80-11bc-4ce3-9eba-59102dbb6e06"), new Guid("bb17d6cb-5d13-4c6f-b441-3ca6e2e3bc71") },
                    { new Guid("8da08a89-463e-420f-a2f2-0c58717f1ddd"), 1, false, new Guid("4e52de80-11bc-4ce3-9eba-59102dbb6e06"), new Guid("945ac710-77fd-49e8-b80f-13261e33c115") },
                    { new Guid("e0b25b91-9f6e-40e5-9231-66f533bd5694"), 2, false, new Guid("4e52de80-11bc-4ce3-9eba-59102dbb6e06"), new Guid("08678161-87ad-4ae7-9cd8-21edec558246") },
                    { new Guid("fa5bc323-211c-4d2b-b990-7da0ffc300f4"), 1, false, new Guid("80f72574-d373-43f9-896f-0db71b80cccd"), new Guid("ea08de75-de76-43a5-a900-26fa7bdb3a8b") },
                    { new Guid("bdf45a20-4daa-4427-9b10-8940cdc3cf71"), 2, false, new Guid("234ec727-daf0-4d6e-afe9-09052d5eb10f"), new Guid("d08512a2-d3de-4108-9bad-4277df054b37") },
                    { new Guid("2de25189-06e4-4b3a-bb86-2f2b1d8cd78f"), 4, false, new Guid("4e52de80-11bc-4ce3-9eba-59102dbb6e06"), new Guid("31791314-91b2-4394-ab92-6be438829445") },
                    { new Guid("fbe21970-74a3-4495-8198-beb904fa1b5e"), 0, true, new Guid("234ec727-daf0-4d6e-afe9-09052d5eb10f"), new Guid("c4aeff11-fe3d-4bcc-b590-aa80a1996b4e") },
                    { new Guid("150e4bde-03f6-41a2-a701-96f9e41be167"), 0, true, new Guid("bb2aefce-f382-4a61-a1fa-083520bcb101"), new Guid("e40be5ba-4f26-4c8c-bef7-24cfdedfb4f0") },
                    { new Guid("59fa614a-525b-4da4-be38-755000d151f2"), 1, false, new Guid("bb2aefce-f382-4a61-a1fa-083520bcb101"), new Guid("579136da-f046-4af1-a80d-a7542e9fc3d2") },
                    { new Guid("c4476e3b-0734-4b15-9d29-e7f377bbf75f"), 3, false, new Guid("4e52de80-11bc-4ce3-9eba-59102dbb6e06"), new Guid("01e86d51-bb0d-458d-8a8b-0add58b661ac") },
                    { new Guid("ab6e012d-0228-4d58-a939-b40a37866ebf"), 3, false, new Guid("bb2aefce-f382-4a61-a1fa-083520bcb101"), new Guid("076380e8-0379-42b3-934d-766b5e7d7707") },
                    { new Guid("439145e7-5f30-457f-a03b-e7b22f25684a"), 4, false, new Guid("bb2aefce-f382-4a61-a1fa-083520bcb101"), new Guid("a33fa429-ead0-4b61-b3e7-153a355f392d") },
                    { new Guid("a7d9f891-d1b2-42f5-bf5c-a3dfb3237758"), 2, false, new Guid("bb2aefce-f382-4a61-a1fa-083520bcb101"), new Guid("4a43647e-c993-47f6-b2f8-155f26c95839") },
                    { new Guid("2e56c44f-b1cd-44e4-a4d3-d6d9cdfafb3f"), 1, false, new Guid("2c5cb800-9d91-448d-85c8-dbcdaa5ed4b6"), new Guid("b05ecef6-95b2-4fac-8e63-c7ed0b7edf73") },
                    { new Guid("2eb0b21c-76c0-462e-b208-a087a91226f3"), 2, false, new Guid("2c5cb800-9d91-448d-85c8-dbcdaa5ed4b6"), new Guid("8ace563b-1e49-4810-9dc5-e2a1bf92c62c") },
                    { new Guid("10f1c539-3c5f-486a-b228-606a0e136b83"), 3, false, new Guid("2c5cb800-9d91-448d-85c8-dbcdaa5ed4b6"), new Guid("6d491ecb-9333-4031-b89e-733d3e7b4cd3") },
                    { new Guid("56ec243d-b842-40fe-88e8-ef1dead7416d"), 4, false, new Guid("2c5cb800-9d91-448d-85c8-dbcdaa5ed4b6"), new Guid("f8979a3b-2962-41a2-bb2c-b1fd5dc4c2bd") },
                    { new Guid("94013c1f-6038-47d5-93a0-7323a7c7cf5a"), 0, true, new Guid("2c5cb800-9d91-448d-85c8-dbcdaa5ed4b6"), new Guid("3ba280f0-1929-4a52-abed-aab0dd020205") }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("37c96910-a4f7-4299-9880-d7d39e1a1060"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6188), new Guid("6f855e6c-8e7d-4e35-a7df-9dcf8e1905a4"), new Guid("3cc64121-cd15-4a44-864a-9dddf34dd129"), 3, null, new Guid("42f2161c-d9a5-4612-91c0-c33406f9c5d1"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6189) },
                    { new Guid("1cc05206-b35d-46be-9009-4290d2a25270"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6161), new Guid("f41835f2-27fa-4b8c-940b-d057d3dace31"), new Guid("3cc64121-cd15-4a44-864a-9dddf34dd129"), 1, null, new Guid("42f2161c-d9a5-4612-91c0-c33406f9c5d1"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6162) },
                    { new Guid("c6605fc6-2459-4235-950a-8f14a58cb39a"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6134), new Guid("63b05fea-2e37-4ed1-aa24-b1427f25d7f6"), new Guid("c10e97cc-550c-46b6-b5a5-c7f0063b67e5"), 3, null, new Guid("42f2161c-d9a5-4612-91c0-c33406f9c5d1"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6135) },
                    { new Guid("cd4dcb4d-4d96-41dc-a78f-64ae4ad1222f"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6069), new Guid("c6594c46-d221-4b52-97c7-6fac7528e471"), new Guid("c10e97cc-550c-46b6-b5a5-c7f0063b67e5"), 1, null, new Guid("42f2161c-d9a5-4612-91c0-c33406f9c5d1"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6070) },
                    { new Guid("92d1724b-23f8-4fb0-9af2-ee846719f133"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6038), new Guid("4bd84d0f-99bd-4897-b607-d789da24955e"), new Guid("ba96b5ff-2e7f-4cfd-af1b-02a2acb6a9d4"), 3, null, new Guid("42f2161c-d9a5-4612-91c0-c33406f9c5d1"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6039) },
                    { new Guid("f7b6c90e-4aff-4d58-8965-7f57c43b985a"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6004), new Guid("7de5adda-d4ef-46da-840b-01dbed82b7a0"), new Guid("ba96b5ff-2e7f-4cfd-af1b-02a2acb6a9d4"), 1, null, new Guid("42f2161c-d9a5-4612-91c0-c33406f9c5d1"), new DateTime(2021, 5, 21, 15, 24, 14, 268, DateTimeKind.Local).AddTicks(6009) }
                });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("7ce40664-5e3b-4634-ba16-9b00cb839e82"), 0, true, new Guid("f7b6c90e-4aff-4d58-8965-7f57c43b985a"), new Guid("c3516ebc-0c19-4862-8f8a-81e12d5680d5") },
                    { new Guid("c0f01165-2efe-4f8c-a4ab-2d8a5c86e1ea"), 4, false, new Guid("37c96910-a4f7-4299-9880-d7d39e1a1060"), new Guid("f778b369-dfd4-49fb-a0af-ef18fac23de1") },
                    { new Guid("ce9fa285-fcc6-486e-990c-d1d8183c1988"), 3, false, new Guid("37c96910-a4f7-4299-9880-d7d39e1a1060"), new Guid("ebbe4589-c510-4438-ad21-97bf684908b6") },
                    { new Guid("d63b7006-c6c5-4555-aa86-d5e8e673295f"), 2, false, new Guid("37c96910-a4f7-4299-9880-d7d39e1a1060"), new Guid("1d80f186-7d01-4dfe-b91e-087b537e6d39") },
                    { new Guid("a5085624-34b6-420f-90c2-e9862f12f316"), 1, false, new Guid("37c96910-a4f7-4299-9880-d7d39e1a1060"), new Guid("736b4453-6b1e-4c5a-a455-5c88e47ae5aa") },
                    { new Guid("5347ab0f-8e0f-47a8-9fe4-724904ef82fb"), 0, true, new Guid("37c96910-a4f7-4299-9880-d7d39e1a1060"), new Guid("469e5ed2-2e70-4790-83ad-9af4ef75790f") },
                    { new Guid("f5b57441-43e6-4cc0-b58a-937d829f4be9"), 4, false, new Guid("1cc05206-b35d-46be-9009-4290d2a25270"), new Guid("bb09dde0-da40-400b-a8b8-5f61c74fdc2b") },
                    { new Guid("c3bdb356-6a93-4765-afe1-6e110659edb3"), 3, false, new Guid("1cc05206-b35d-46be-9009-4290d2a25270"), new Guid("c3333419-3209-4d26-9101-812807039a42") },
                    { new Guid("912daff4-5ecc-4e14-934d-fcfd7aa1c158"), 2, false, new Guid("1cc05206-b35d-46be-9009-4290d2a25270"), new Guid("37785e1d-fcb0-4113-bdac-99ef7b56f90c") },
                    { new Guid("64a19d9c-a92e-4109-9f9f-ad126e192446"), 1, false, new Guid("1cc05206-b35d-46be-9009-4290d2a25270"), new Guid("c2b02592-56a4-4bdc-8a1d-d61c4040b245") },
                    { new Guid("c953a5bf-a57c-493e-b539-a4e0e2979fb0"), 0, true, new Guid("1cc05206-b35d-46be-9009-4290d2a25270"), new Guid("d3bb5e76-ee66-4714-ae84-47b2f1d95f71") },
                    { new Guid("d1ac1336-9e47-4014-b734-41ce94c4dbef"), 4, false, new Guid("c6605fc6-2459-4235-950a-8f14a58cb39a"), new Guid("e44b1f61-90eb-44ad-b6ff-84dc2d1eca0c") },
                    { new Guid("bd491925-9146-4270-b81a-8311154cbada"), 3, false, new Guid("c6605fc6-2459-4235-950a-8f14a58cb39a"), new Guid("dc8c32e3-1174-495a-b9fa-5ee4959adbce") },
                    { new Guid("013ba1f5-0cde-4701-9320-b1c3821dca58"), 2, false, new Guid("c6605fc6-2459-4235-950a-8f14a58cb39a"), new Guid("2578e1c4-adbc-48c4-a349-e0c626bf9d36") },
                    { new Guid("a2ef69bb-a09b-47ad-b315-2a60ca84b6a8"), 1, false, new Guid("c6605fc6-2459-4235-950a-8f14a58cb39a"), new Guid("ca77f135-5a90-4793-81aa-6e17fbb4e8c3") },
                    { new Guid("b8d2d72a-cc79-4711-b802-e24444229035"), 0, true, new Guid("c6605fc6-2459-4235-950a-8f14a58cb39a"), new Guid("863e9fba-4869-4855-835b-90cd254b7f7c") },
                    { new Guid("319acbe9-6d4e-44a6-b5d3-074a8ac3c9fc"), 4, false, new Guid("cd4dcb4d-4d96-41dc-a78f-64ae4ad1222f"), new Guid("8aee8ea8-70bd-4424-bdef-9f306af121f9") },
                    { new Guid("20ea13fa-c2f7-4ec4-aa72-03a12a22b7e6"), 3, false, new Guid("cd4dcb4d-4d96-41dc-a78f-64ae4ad1222f"), new Guid("b1d4f086-1231-4eae-9280-82505e245256") },
                    { new Guid("b6a74c72-a429-4171-b63a-db9b363fd254"), 2, false, new Guid("cd4dcb4d-4d96-41dc-a78f-64ae4ad1222f"), new Guid("1f453586-7302-4b67-8cc8-062324114408") },
                    { new Guid("462a1d36-18d2-42ab-b688-0b564f512b96"), 1, false, new Guid("cd4dcb4d-4d96-41dc-a78f-64ae4ad1222f"), new Guid("f0496687-42aa-42a1-ac7e-a6c76ee44426") },
                    { new Guid("cdd1d6af-dc27-4388-ac28-ac4e901d1e91"), 0, true, new Guid("cd4dcb4d-4d96-41dc-a78f-64ae4ad1222f"), new Guid("97639e4b-7a86-453b-9e92-5c318ec1d2c7") },
                    { new Guid("9770e6cf-20d9-4055-835a-b62fc78f9e6f"), 4, false, new Guid("92d1724b-23f8-4fb0-9af2-ee846719f133"), new Guid("2ccc210b-a607-45f2-96d9-b60ec1929fe6") },
                    { new Guid("184d07b7-2112-4633-a01e-457907eaabe2"), 3, false, new Guid("92d1724b-23f8-4fb0-9af2-ee846719f133"), new Guid("704664e2-12b4-42c8-9c4e-82ec7eac0449") },
                    { new Guid("615ae0f1-7ead-4e2b-a406-693373148588"), 2, false, new Guid("92d1724b-23f8-4fb0-9af2-ee846719f133"), new Guid("2650d896-bcf6-4608-89bd-18c8c43f9ac9") },
                    { new Guid("9dc887f8-574c-4d2b-85f4-78a7a0b6fd02"), 1, false, new Guid("92d1724b-23f8-4fb0-9af2-ee846719f133"), new Guid("b5ee87ea-6f83-448c-a7dc-6720a01060a2") },
                    { new Guid("f03f9b1d-28fe-4702-bca1-fea936f67b37"), 0, true, new Guid("92d1724b-23f8-4fb0-9af2-ee846719f133"), new Guid("ffd0bff3-40e4-443f-a625-9cb329fd5b40") },
                    { new Guid("cb41610e-e2ba-494c-a9df-086850809205"), 4, false, new Guid("f7b6c90e-4aff-4d58-8965-7f57c43b985a"), new Guid("e117147d-7ff8-4bf3-8534-db1819fecec9") },
                    { new Guid("6108c18f-ce63-415b-b72d-f2802219d601"), 3, false, new Guid("f7b6c90e-4aff-4d58-8965-7f57c43b985a"), new Guid("aba3c46d-6a71-4dfe-a967-e09b7612cc31") },
                    { new Guid("153961b6-e433-4980-8a95-70d3d4f7114d"), 2, false, new Guid("f7b6c90e-4aff-4d58-8965-7f57c43b985a"), new Guid("a77855c9-01b7-4f5a-a93e-f0fe677c258f") },
                    { new Guid("2e68e9c5-5eb4-49ee-8016-4eaa1d3ae0dd"), 1, false, new Guid("f7b6c90e-4aff-4d58-8965-7f57c43b985a"), new Guid("96bef00d-efb0-4531-a8d1-fb04e34a6b45") }
                });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[,]
                {
                    { new Guid("b53af185-47d3-433b-96e4-e770b78e1564"), new Guid("fbe21970-74a3-4495-8198-beb904fa1b5e"), new DateTime(2021, 5, 21, 15, 24, 14, 282, DateTimeKind.Local).AddTicks(7510), new Guid("234ec727-daf0-4d6e-afe9-09052d5eb10f"), null, new DateTime(2021, 5, 21, 15, 24, 14, 282, DateTimeKind.Local).AddTicks(7519), new Guid("d574be54-0eab-448d-8169-7da2367e7ffb") },
                    { new Guid("fb603a97-3574-4932-8b15-ff6aabec8254"), new Guid("86a98de2-681e-4ee3-9187-d7fb4fa0cd79"), new DateTime(2021, 5, 21, 15, 24, 14, 282, DateTimeKind.Local).AddTicks(8864), new Guid("7e3dbc1e-07b2-4ec9-ab9e-392a352ae06c"), null, new DateTime(2021, 5, 21, 15, 24, 14, 282, DateTimeKind.Local).AddTicks(8865), new Guid("d574be54-0eab-448d-8169-7da2367e7ffb") }
                });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[,]
                {
                    { new Guid("994858cc-d060-46b1-b1b6-1afcd036fca0"), new Guid("cdd1d6af-dc27-4388-ac28-ac4e901d1e91"), new DateTime(2021, 5, 21, 15, 24, 14, 282, DateTimeKind.Local).AddTicks(8848), new Guid("cd4dcb4d-4d96-41dc-a78f-64ae4ad1222f"), null, new DateTime(2021, 5, 21, 15, 24, 14, 282, DateTimeKind.Local).AddTicks(8852), new Guid("d574be54-0eab-448d-8169-7da2367e7ffb") },
                    { new Guid("226545ee-73ef-4cb5-b515-7536018376ce"), new Guid("b8d2d72a-cc79-4711-b802-e24444229035"), new DateTime(2021, 5, 21, 15, 24, 14, 282, DateTimeKind.Local).AddTicks(8868), new Guid("c6605fc6-2459-4235-950a-8f14a58cb39a"), null, new DateTime(2021, 5, 21, 15, 24, 14, 282, DateTimeKind.Local).AddTicks(8869), new Guid("d574be54-0eab-448d-8169-7da2367e7ffb") }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exam_period");

            migrationBuilder.DropTable(
                name: "question_answers");

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
