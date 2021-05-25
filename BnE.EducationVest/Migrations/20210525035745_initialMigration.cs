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
                    { new Guid("461b735b-e7fa-488b-a647-b2d8c0093928"), new DateTime(2021, 5, 25, 0, 57, 44, 632, DateTimeKind.Local).AddTicks(7680), 1, 2, null, new DateTime(2021, 5, 25, 0, 57, 44, 632, DateTimeKind.Local).AddTicks(7688) },
                    { new Guid("91c96b2f-fd2d-4ee9-ab00-e0e375e75f00"), new DateTime(2021, 5, 25, 0, 57, 44, 633, DateTimeKind.Local).AddTicks(1693), 1, 1, null, new DateTime(2021, 5, 25, 0, 57, 44, 633, DateTimeKind.Local).AddTicks(1694) },
                    { new Guid("11d3c757-fd68-4231-830a-502e7945f628"), new DateTime(2021, 5, 25, 0, 57, 44, 633, DateTimeKind.Local).AddTicks(1701), 2, 1, null, new DateTime(2021, 5, 25, 0, 57, 44, 633, DateTimeKind.Local).AddTicks(1702) }
                });

            migrationBuilder.InsertData(
                table: "incremented_text",
                columns: new[] { "id", "content", "increments" },
                values: new object[,]
                {
                    { new Guid("5e320bd2-c02f-433b-82fd-31e2436f3b82"), "60°", null },
                    { new Guid("6e8e98b5-958d-4f91-abb6-8734af975acb"), "30°", null },
                    { new Guid("60d3f916-3300-44dd-9686-4745cfcb098e"), "45°", null },
                    { new Guid("3f94c1d4-5373-4cdd-8516-d8b2bba13efb"), "22,5°", null },
                    { new Guid("99fcf509-87a4-4b63-9d22-600df113b45e"), "15°", null },
                    { new Guid("9a9463e9-f16d-4329-ade8-7f91264bd8d4"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("f1615972-713f-4b36-8509-3923dfcf0bd1"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("722e6d52-520e-468d-a78e-1032178a5b6e"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("2397ef27-b048-4702-9fe7-d9fba6f33293"), "menor do que 128.", null },
                    { new Guid("d885ded8-3007-48e5-b7cf-daca9ad0cf11"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("72808da9-282b-4931-9acf-427dfdbaa545"), "5,34", null },
                    { new Guid("9d510a3e-fc07-445b-993a-91a44364bb66"), "3,68", null },
                    { new Guid("51fd6eb8-4a17-4e52-b0fa-c650f8c94f21"), "6.62", null },
                    { new Guid("0e6b4196-117c-407c-90db-fc7c381aa743"), "8,32", null },
                    { new Guid("a0f961c5-7335-4a1c-acae-05d59762b6f0"), "4,64", null },
                    { new Guid("f768205e-59ad-409b-9441-79a4385e3b9a"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("7d3deb5c-35e2-4044-88ed-87cf6479db43"), "entre 128 e 129.", null },
                    { new Guid("c72d65e3-4463-4b14-951c-3f6985f74f60"), "entre 129 e 130.", null },
                    { new Guid("d2191e68-1f8c-4b1c-ab09-0fb5b90a3b9f"), "entre 130 e 131.", null },
                    { new Guid("00c9ca9c-433b-4b7d-8d96-5f9398bf1436"), "30°", null },
                    { new Guid("33f33807-f2a2-4fde-964c-ae5f2248654f"), "45°", null },
                    { new Guid("27d4e750-d749-41df-84a0-52421e86b129"), "22,5°", null },
                    { new Guid("ea6406a7-cbdf-49bb-a63c-1cae8001e3d9"), "15°", null },
                    { new Guid("e2f0a211-a823-4e2a-81f5-0c90b9bfaa79"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("f4eeb0d1-3e2f-414a-8592-9db022f735b7"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("ee8e306c-f208-49dc-9d57-22025221017c"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("ecdfbda5-f06f-4cd1-851f-50c6b2180b41"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("7959a06b-9b4d-4238-8428-e80b4270004d"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("5a30da59-3e71-4f99-9023-06c2edb1fd78"), "5,34", null },
                    { new Guid("42deee22-d27b-49fb-a280-d96b42666097"), "3,68", null },
                    { new Guid("e48df4dc-baf6-44c4-ae39-9802bed894ee"), "6.62", null },
                    { new Guid("4fee2f7a-27f1-4875-bd50-56beca5e69b9"), "8,32", null },
                    { new Guid("b940cc5d-684b-4789-b4f0-3def2b031a38"), "4,64", null },
                    { new Guid("10521945-1579-4cdd-a585-8eb711350f6d"), "maior que 131", null },
                    { new Guid("d2600c24-76d6-4885-8d24-a889c39805d0"), "maior que 131", null },
                    { new Guid("837a91ea-d1ba-44ec-bd08-296e4247d09b"), "entre 130 e 131.", null },
                    { new Guid("e31c5178-4eab-422c-a29b-528b29c5ba53"), "entre 128 e 129.", null },
                    { new Guid("194c904f-b4c4-4adc-9b85-daaaebe42b21"), "60°", null },
                    { new Guid("a2e800e0-b02a-4fab-b9d5-27e359dab4ea"), "entre 128 e 129.", null },
                    { new Guid("4a85ed33-05ea-45db-8f09-df6b660ebd31"), "menor do que 128.", null },
                    { new Guid("c151b00b-af48-406d-a486-38c339357e99"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("246955cc-9f53-41c5-9500-d0931be54061"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("d7e2dd98-d0bd-4466-b5b2-5107cc9a0019"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("27f02250-5aca-4259-b313-35e54d7649ec"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("a1f567ee-fca7-48cd-8efb-a0b8c8492470"), "entre 129 e 130.", null },
                    { new Guid("72570327-7346-47e9-a066-67cd6a733c0e"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("b30bc3d5-b97c-4a04-93f9-71fd6c693d3f"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("bdd066fe-3de0-43bc-a560-2104fdf378ad"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("cfc89fdf-b0ff-4ae5-8eb2-454a98b4a0fb"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("c70f9540-aef1-4585-b0a9-80feef67a4d4"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("f073300e-3551-463a-b979-74a526c6aebe"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("67025350-84c4-4739-9b1b-e20f2e37ae7d"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("7c2a684b-6e1c-49a0-a725-f0bcaf6cc09e"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("67429d66-1e40-4e57-ad83-0bd525048a00"), "entre 129 e 130.", null },
                    { new Guid("37540030-513b-4d13-8b7f-8b148e3e8c28"), "entre 130 e 131.", null },
                    { new Guid("ae032386-bac4-437e-9d4a-b5e0d424e074"), "4,64", null },
                    { new Guid("cbd3bf01-4e41-45ea-bc2b-30857524e5c5"), "menor do que 128.", null },
                    { new Guid("540e43cb-e960-4a63-88c3-b8671488928f"), "60°", null },
                    { new Guid("15aec200-9909-489d-8a7d-3e4aca90e894"), "30°", null },
                    { new Guid("ba7a6d10-99c1-406b-8c7e-fcb01de770d6"), "45°", null },
                    { new Guid("f7abf2bb-e873-403e-bc09-060c245b2fc7"), "22,5°", null },
                    { new Guid("2c1e4b36-ad95-4aea-833d-58cb25b2e5c1"), "15°", null },
                    { new Guid("0978a600-ae6a-4058-9687-7cfdf9d318cb"), "maior que 131", null },
                    { new Guid("0040ec71-ff3a-4cb7-be4f-876b664716d9"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("72744b88-394a-45a8-b36d-6bf3d9bb24b5"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("65a04495-5c1d-4593-8bf0-646bcfe4b449"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("867635e3-1718-4b34-aca4-92785cf543f3"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("7a73a81b-7e6c-4089-acd8-0c4eb2faa348"), "5,34", null },
                    { new Guid("f90548fc-79ad-4ac5-b4b8-3356ebc1ba5b"), "3,68", null },
                    { new Guid("de79fa7a-819e-4eac-991a-4c1e828fb957"), "6.62", null },
                    { new Guid("ea5c02c5-e98a-4b28-9497-758c0b0e4290"), "8,32", null },
                    { new Guid("68936374-5ab7-4b4c-9d34-8265ccff1454"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("2eaea1d4-1215-4707-8ebb-4d7f8fa78a51"), new DateTime(2021, 5, 25, 0, 57, 44, 624, DateTimeKind.Local).AddTicks(1188), "Português", null, null, new DateTime(2021, 5, 25, 0, 57, 44, 624, DateTimeKind.Local).AddTicks(1193) },
                    { new Guid("2ebff993-475d-4e07-9c31-b3f2c07c36b8"), new DateTime(2021, 5, 25, 0, 57, 44, 623, DateTimeKind.Local).AddTicks(9924), "Matemática", null, null, new DateTime(2021, 5, 25, 0, 57, 44, 624, DateTimeKind.Local).AddTicks(381) }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "birth_date", "cognito_user_id", "created_date", "email", "gender", "is_teacher", "name", "phone_number", "removed_date", "updated_date", "address.cep", "address.city", "address.neighborhood", "address.number", "address.state", "address.street" },
                values: new object[] { new Guid("579cb650-65e2-4798-be78-19cb27794a6d"), new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e32ca6c-2a66-4ea6-a0c4-cf655dab5191"), new DateTime(2021, 5, 25, 0, 57, 44, 632, DateTimeKind.Local).AddTicks(445), "sacchitiellogiovanni@gmail.com", "Masculino", false, "Giovanni Sacchitiello", "11991392711", null, new DateTime(2021, 5, 25, 0, 57, 44, 632, DateTimeKind.Local).AddTicks(459), "03320020", "São Paulo", "Carrão", "148", "SP", "Rua antonio ciucio" });

            migrationBuilder.InsertData(
                table: "exam_period",
                columns: new[] { "id", "close_date", "exam_id", "open_date" },
                values: new object[,]
                {
                    { new Guid("dbe0ad3c-1163-4dd4-90df-9e60c25516ff"), new DateTime(2021, 5, 29, 12, 0, 0, 0, DateTimeKind.Local), new Guid("461b735b-e7fa-488b-a647-b2d8c0093928"), new DateTime(2021, 5, 29, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("0e9d0a4e-42ae-4808-aaa3-c46d1cf18183"), new DateTime(2021, 5, 30, 12, 0, 0, 0, DateTimeKind.Local), new Guid("461b735b-e7fa-488b-a647-b2d8c0093928"), new DateTime(2021, 5, 30, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("6a72f478-3d00-4d5e-8510-eb36e1351c15"), new DateTime(2021, 5, 25, 4, 57, 44, 633, DateTimeKind.Local).AddTicks(1664), new Guid("91c96b2f-fd2d-4ee9-ab00-e0e375e75f00"), new DateTime(2021, 5, 25, 0, 57, 44, 633, DateTimeKind.Local).AddTicks(1664) },
                    { new Guid("625400bd-2cc3-46d3-80ed-f83ac73628fe"), new DateTime(2021, 5, 26, 2, 57, 44, 633, DateTimeKind.Local).AddTicks(1664), new Guid("91c96b2f-fd2d-4ee9-ab00-e0e375e75f00"), new DateTime(2021, 5, 26, 0, 57, 44, 633, DateTimeKind.Local).AddTicks(1664) },
                    { new Guid("2e3a3bce-3f02-41fc-8f26-1c787767e13c"), new DateTime(2021, 5, 23, 2, 57, 44, 633, DateTimeKind.Local).AddTicks(1696), new Guid("11d3c757-fd68-4231-830a-502e7945f628"), new DateTime(2021, 5, 23, 0, 57, 44, 633, DateTimeKind.Local).AddTicks(1696) },
                    { new Guid("7e9c7810-0649-4645-8a25-2d899b4a1e8c"), new DateTime(2021, 5, 24, 2, 57, 44, 633, DateTimeKind.Local).AddTicks(1696), new Guid("11d3c757-fd68-4231-830a-502e7945f628"), new DateTime(2021, 5, 24, 0, 57, 44, 633, DateTimeKind.Local).AddTicks(1696) }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("4b0e8f0d-410e-44d7-b0dc-999d7c90208c"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(240), new Guid("67025350-84c4-4739-9b1b-e20f2e37ae7d"), new Guid("461b735b-e7fa-488b-a647-b2d8c0093928"), 0, null, new Guid("2ebff993-475d-4e07-9c31-b3f2c07c36b8"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(246) },
                    { new Guid("a0217705-d9e7-4eb4-ad65-4961ea1fecba"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(2996), new Guid("c70f9540-aef1-4585-b0a9-80feef67a4d4"), new Guid("461b735b-e7fa-488b-a647-b2d8c0093928"), 2, null, new Guid("2eaea1d4-1215-4707-8ebb-4d7f8fa78a51"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(2997) },
                    { new Guid("8ba5cd31-6d47-4939-8e63-1e1d592eba5b"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3024), new Guid("bdd066fe-3de0-43bc-a560-2104fdf378ad"), new Guid("91c96b2f-fd2d-4ee9-ab00-e0e375e75f00"), 0, null, new Guid("2ebff993-475d-4e07-9c31-b3f2c07c36b8"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3025) },
                    { new Guid("e0b18dcf-48e7-4319-a93c-ff24e5f79d0f"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3052), new Guid("7c2a684b-6e1c-49a0-a725-f0bcaf6cc09e"), new Guid("91c96b2f-fd2d-4ee9-ab00-e0e375e75f00"), 2, null, new Guid("2eaea1d4-1215-4707-8ebb-4d7f8fa78a51"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3053) },
                    { new Guid("8e6ec2fb-3a8d-4500-9ff1-fffcf6dbecf3"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3111), new Guid("27f02250-5aca-4259-b313-35e54d7649ec"), new Guid("11d3c757-fd68-4231-830a-502e7945f628"), 0, null, new Guid("2ebff993-475d-4e07-9c31-b3f2c07c36b8"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3112) },
                    { new Guid("9154a6f7-7622-4d09-b502-1f4ae7a05fd5"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3136), new Guid("246955cc-9f53-41c5-9500-d0931be54061"), new Guid("11d3c757-fd68-4231-830a-502e7945f628"), 2, null, new Guid("2eaea1d4-1215-4707-8ebb-4d7f8fa78a51"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3137) }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[] { new Guid("b1f10595-07f3-4c3a-8a6f-0334755c95f6"), new DateTime(2021, 5, 25, 0, 57, 44, 624, DateTimeKind.Local).AddTicks(1196), "Porcentagem", null, new Guid("2ebff993-475d-4e07-9c31-b3f2c07c36b8"), new DateTime(2021, 5, 25, 0, 57, 44, 624, DateTimeKind.Local).AddTicks(1197) });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("4b007227-8981-413f-b9d3-7e534ecdc79b"), 1, false, new Guid("8ba5cd31-6d47-4939-8e63-1e1d592eba5b"), new Guid("e31c5178-4eab-422c-a29b-528b29c5ba53") },
                    { new Guid("886be759-1ae8-477b-945c-19630427f5eb"), 4, false, new Guid("8ba5cd31-6d47-4939-8e63-1e1d592eba5b"), new Guid("d2600c24-76d6-4885-8d24-a889c39805d0") },
                    { new Guid("c14d9e43-c684-4e80-b0bd-e166d61d619c"), 0, true, new Guid("e0b18dcf-48e7-4319-a93c-ff24e5f79d0f"), new Guid("d885ded8-3007-48e5-b7cf-daca9ad0cf11") },
                    { new Guid("1e14dada-eda3-4e59-86ab-7c9861e9c0f6"), 1, false, new Guid("e0b18dcf-48e7-4319-a93c-ff24e5f79d0f"), new Guid("722e6d52-520e-468d-a78e-1032178a5b6e") },
                    { new Guid("150ff2bd-14be-46fe-a87d-109d401dbd12"), 2, false, new Guid("e0b18dcf-48e7-4319-a93c-ff24e5f79d0f"), new Guid("f768205e-59ad-409b-9441-79a4385e3b9a") },
                    { new Guid("4d16012d-b179-4106-b2ca-5a6dc612a57c"), 3, false, new Guid("e0b18dcf-48e7-4319-a93c-ff24e5f79d0f"), new Guid("f1615972-713f-4b36-8509-3923dfcf0bd1") },
                    { new Guid("660bb5a6-cac7-4cd4-a60a-9e1460e84038"), 4, false, new Guid("e0b18dcf-48e7-4319-a93c-ff24e5f79d0f"), new Guid("9a9463e9-f16d-4329-ade8-7f91264bd8d4") },
                    { new Guid("4fec59e7-cc05-4a3a-b7cd-fcc377903cfe"), 3, false, new Guid("8ba5cd31-6d47-4939-8e63-1e1d592eba5b"), new Guid("837a91ea-d1ba-44ec-bd08-296e4247d09b") },
                    { new Guid("433df528-020a-4935-9531-7fd671c05c98"), 0, true, new Guid("8e6ec2fb-3a8d-4500-9ff1-fffcf6dbecf3"), new Guid("2397ef27-b048-4702-9fe7-d9fba6f33293") },
                    { new Guid("ae41b6a6-b679-4ee2-af4d-31037054d11e"), 2, false, new Guid("8e6ec2fb-3a8d-4500-9ff1-fffcf6dbecf3"), new Guid("c72d65e3-4463-4b14-951c-3f6985f74f60") },
                    { new Guid("6d6e2b3e-1512-4caa-81dc-06f665312a32"), 3, false, new Guid("8e6ec2fb-3a8d-4500-9ff1-fffcf6dbecf3"), new Guid("d2191e68-1f8c-4b1c-ab09-0fb5b90a3b9f") },
                    { new Guid("68eca955-2e50-4f7a-a5b0-9c9be96e560d"), 4, false, new Guid("8e6ec2fb-3a8d-4500-9ff1-fffcf6dbecf3"), new Guid("10521945-1579-4cdd-a585-8eb711350f6d") },
                    { new Guid("d777f247-7583-4d8a-8fbb-f06750a316c1"), 0, true, new Guid("9154a6f7-7622-4d09-b502-1f4ae7a05fd5"), new Guid("7959a06b-9b4d-4238-8428-e80b4270004d") },
                    { new Guid("25b558d7-8370-4b3b-9358-461a1f04ee4b"), 1, false, new Guid("9154a6f7-7622-4d09-b502-1f4ae7a05fd5"), new Guid("ecdfbda5-f06f-4cd1-851f-50c6b2180b41") },
                    { new Guid("2ccf246b-4dd2-4361-a6af-aee652e33bb3"), 2, false, new Guid("9154a6f7-7622-4d09-b502-1f4ae7a05fd5"), new Guid("ee8e306c-f208-49dc-9d57-22025221017c") },
                    { new Guid("de5d5feb-f043-46fe-a2af-98ef8a17f800"), 1, false, new Guid("8e6ec2fb-3a8d-4500-9ff1-fffcf6dbecf3"), new Guid("7d3deb5c-35e2-4044-88ed-87cf6479db43") },
                    { new Guid("ead84342-f5a5-4060-9c90-f5801aef3ded"), 2, false, new Guid("8ba5cd31-6d47-4939-8e63-1e1d592eba5b"), new Guid("67429d66-1e40-4e57-ad83-0bd525048a00") },
                    { new Guid("8dccf9c2-d6ca-4245-a958-e3d7dcf08596"), 4, false, new Guid("9154a6f7-7622-4d09-b502-1f4ae7a05fd5"), new Guid("e2f0a211-a823-4e2a-81f5-0c90b9bfaa79") },
                    { new Guid("31aee890-3d61-4933-8604-fd6f9324590f"), 0, true, new Guid("8ba5cd31-6d47-4939-8e63-1e1d592eba5b"), new Guid("cbd3bf01-4e41-45ea-bc2b-30857524e5c5") },
                    { new Guid("d9e38739-143b-4ddc-8ac5-8af6dd3f8d1f"), 0, true, new Guid("4b0e8f0d-410e-44d7-b0dc-999d7c90208c"), new Guid("4a85ed33-05ea-45db-8f09-df6b660ebd31") },
                    { new Guid("1b245c8c-8e7a-4276-9e81-517d1f741557"), 1, false, new Guid("4b0e8f0d-410e-44d7-b0dc-999d7c90208c"), new Guid("a2e800e0-b02a-4fab-b9d5-27e359dab4ea") },
                    { new Guid("123f5bff-f1a8-443d-9092-6568768f8ec3"), 3, false, new Guid("9154a6f7-7622-4d09-b502-1f4ae7a05fd5"), new Guid("f4eeb0d1-3e2f-414a-8592-9db022f735b7") },
                    { new Guid("ff3b2281-661b-49d3-b239-1519d9591a22"), 3, false, new Guid("4b0e8f0d-410e-44d7-b0dc-999d7c90208c"), new Guid("37540030-513b-4d13-8b7f-8b148e3e8c28") },
                    { new Guid("06fc6e40-fb8d-42bf-96b6-b876d541cac6"), 4, false, new Guid("4b0e8f0d-410e-44d7-b0dc-999d7c90208c"), new Guid("0978a600-ae6a-4058-9687-7cfdf9d318cb") },
                    { new Guid("1e6f4cc3-1563-4ac6-8295-870d742f9758"), 2, false, new Guid("4b0e8f0d-410e-44d7-b0dc-999d7c90208c"), new Guid("a1f567ee-fca7-48cd-8efb-a0b8c8492470") },
                    { new Guid("2d3d0b1d-5aa8-4bac-acaf-dc8834cafed3"), 1, false, new Guid("a0217705-d9e7-4eb4-ad65-4961ea1fecba"), new Guid("65a04495-5c1d-4593-8bf0-646bcfe4b449") },
                    { new Guid("0a3983fd-8f4e-4536-b7ca-1ae500224199"), 2, false, new Guid("a0217705-d9e7-4eb4-ad65-4961ea1fecba"), new Guid("72744b88-394a-45a8-b36d-6bf3d9bb24b5") },
                    { new Guid("87826f3d-40c0-4651-a6f3-3c039bfd851f"), 3, false, new Guid("a0217705-d9e7-4eb4-ad65-4961ea1fecba"), new Guid("68936374-5ab7-4b4c-9d34-8265ccff1454") },
                    { new Guid("0606ce8a-d30b-497d-a852-59559441f77f"), 4, false, new Guid("a0217705-d9e7-4eb4-ad65-4961ea1fecba"), new Guid("0040ec71-ff3a-4cb7-be4f-876b664716d9") },
                    { new Guid("27b47fef-97a3-46c7-952e-9118ff79b1b2"), 0, true, new Guid("a0217705-d9e7-4eb4-ad65-4961ea1fecba"), new Guid("867635e3-1718-4b34-aca4-92785cf543f3") }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("94e69004-8da0-4075-aa9f-c99937335f11"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3151), new Guid("c151b00b-af48-406d-a486-38c339357e99"), new Guid("11d3c757-fd68-4231-830a-502e7945f628"), 3, null, new Guid("b1f10595-07f3-4c3a-8a6f-0334755c95f6"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3151) },
                    { new Guid("ab554581-baaa-4656-af70-076b150b7e96"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3124), new Guid("d7e2dd98-d0bd-4466-b5b2-5107cc9a0019"), new Guid("11d3c757-fd68-4231-830a-502e7945f628"), 1, null, new Guid("b1f10595-07f3-4c3a-8a6f-0334755c95f6"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3125) },
                    { new Guid("c5a46c5f-9a81-4ae6-8df3-9da959ddaaa9"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3065), new Guid("72570327-7346-47e9-a066-67cd6a733c0e"), new Guid("91c96b2f-fd2d-4ee9-ab00-e0e375e75f00"), 3, null, new Guid("b1f10595-07f3-4c3a-8a6f-0334755c95f6"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3066) },
                    { new Guid("0cc54ab8-adeb-4a63-948e-d5e65cad8ef4"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3040), new Guid("b30bc3d5-b97c-4a04-93f9-71fd6c693d3f"), new Guid("91c96b2f-fd2d-4ee9-ab00-e0e375e75f00"), 1, null, new Guid("b1f10595-07f3-4c3a-8a6f-0334755c95f6"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3040) },
                    { new Guid("d909bfa4-abbe-4ca0-8a01-1389564d4af9"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3011), new Guid("cfc89fdf-b0ff-4ae5-8eb2-454a98b4a0fb"), new Guid("461b735b-e7fa-488b-a647-b2d8c0093928"), 3, null, new Guid("b1f10595-07f3-4c3a-8a6f-0334755c95f6"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(3012) },
                    { new Guid("abed963d-1cb9-45c7-8715-90ac1d1e5b6f"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(2977), new Guid("f073300e-3551-463a-b979-74a526c6aebe"), new Guid("461b735b-e7fa-488b-a647-b2d8c0093928"), 1, null, new Guid("b1f10595-07f3-4c3a-8a6f-0334755c95f6"), new DateTime(2021, 5, 25, 0, 57, 44, 625, DateTimeKind.Local).AddTicks(2982) }
                });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("5bea2636-14e0-495d-9781-91a15ed64c3e"), 0, true, new Guid("abed963d-1cb9-45c7-8715-90ac1d1e5b6f"), new Guid("ae032386-bac4-437e-9d4a-b5e0d424e074") },
                    { new Guid("b8896c7e-6048-490f-9703-48068a041975"), 4, false, new Guid("94e69004-8da0-4075-aa9f-c99937335f11"), new Guid("194c904f-b4c4-4adc-9b85-daaaebe42b21") },
                    { new Guid("d9c8b115-689f-453f-8559-2983c2cddab6"), 3, false, new Guid("94e69004-8da0-4075-aa9f-c99937335f11"), new Guid("00c9ca9c-433b-4b7d-8d96-5f9398bf1436") },
                    { new Guid("3bd01a8a-5266-4e56-80a5-38f300ba4e49"), 2, false, new Guid("94e69004-8da0-4075-aa9f-c99937335f11"), new Guid("33f33807-f2a2-4fde-964c-ae5f2248654f") },
                    { new Guid("b6bedc49-e099-442c-9248-09d9262781b3"), 1, false, new Guid("94e69004-8da0-4075-aa9f-c99937335f11"), new Guid("27d4e750-d749-41df-84a0-52421e86b129") },
                    { new Guid("dbc30466-2874-4a1a-9250-fbc390f67ff4"), 0, true, new Guid("94e69004-8da0-4075-aa9f-c99937335f11"), new Guid("ea6406a7-cbdf-49bb-a63c-1cae8001e3d9") },
                    { new Guid("09d84256-125a-4d6b-af7c-0b3593ca027c"), 4, false, new Guid("ab554581-baaa-4656-af70-076b150b7e96"), new Guid("5a30da59-3e71-4f99-9023-06c2edb1fd78") },
                    { new Guid("6dea11b3-6bc4-4776-9361-e784d864cf0f"), 3, false, new Guid("ab554581-baaa-4656-af70-076b150b7e96"), new Guid("42deee22-d27b-49fb-a280-d96b42666097") },
                    { new Guid("dc464046-4878-4651-b87f-24184a23666c"), 2, false, new Guid("ab554581-baaa-4656-af70-076b150b7e96"), new Guid("e48df4dc-baf6-44c4-ae39-9802bed894ee") },
                    { new Guid("354a8f4a-acd5-49e8-827a-596aed144b8f"), 1, false, new Guid("ab554581-baaa-4656-af70-076b150b7e96"), new Guid("4fee2f7a-27f1-4875-bd50-56beca5e69b9") },
                    { new Guid("af776378-657c-4d30-a64b-685cbf8b83f2"), 0, true, new Guid("ab554581-baaa-4656-af70-076b150b7e96"), new Guid("b940cc5d-684b-4789-b4f0-3def2b031a38") },
                    { new Guid("320b5b94-2a29-4e5e-9ca6-d272a50cb055"), 4, false, new Guid("c5a46c5f-9a81-4ae6-8df3-9da959ddaaa9"), new Guid("5e320bd2-c02f-433b-82fd-31e2436f3b82") },
                    { new Guid("4ad0a30e-e2b9-4ff2-b152-d9850426d348"), 3, false, new Guid("c5a46c5f-9a81-4ae6-8df3-9da959ddaaa9"), new Guid("6e8e98b5-958d-4f91-abb6-8734af975acb") },
                    { new Guid("16fe7ad9-7b81-403d-bbf1-97544b7b1e38"), 2, false, new Guid("c5a46c5f-9a81-4ae6-8df3-9da959ddaaa9"), new Guid("60d3f916-3300-44dd-9686-4745cfcb098e") },
                    { new Guid("45a5346c-d004-4b4c-8833-80ed0b2bc49b"), 1, false, new Guid("c5a46c5f-9a81-4ae6-8df3-9da959ddaaa9"), new Guid("3f94c1d4-5373-4cdd-8516-d8b2bba13efb") },
                    { new Guid("fde78064-6fa6-4d6c-8e90-24ddcde3012b"), 0, true, new Guid("c5a46c5f-9a81-4ae6-8df3-9da959ddaaa9"), new Guid("99fcf509-87a4-4b63-9d22-600df113b45e") },
                    { new Guid("afcff988-b20e-408c-bb05-7b2e4b92f519"), 4, false, new Guid("0cc54ab8-adeb-4a63-948e-d5e65cad8ef4"), new Guid("72808da9-282b-4931-9acf-427dfdbaa545") },
                    { new Guid("b2db1a65-51f4-4b5d-b69f-06e7d51e5547"), 3, false, new Guid("0cc54ab8-adeb-4a63-948e-d5e65cad8ef4"), new Guid("9d510a3e-fc07-445b-993a-91a44364bb66") },
                    { new Guid("54621536-9bee-4f98-a3f6-1b8598048c7b"), 2, false, new Guid("0cc54ab8-adeb-4a63-948e-d5e65cad8ef4"), new Guid("51fd6eb8-4a17-4e52-b0fa-c650f8c94f21") },
                    { new Guid("be388052-5b96-4252-a8af-c92bf4ec4422"), 1, false, new Guid("0cc54ab8-adeb-4a63-948e-d5e65cad8ef4"), new Guid("0e6b4196-117c-407c-90db-fc7c381aa743") },
                    { new Guid("1336c69d-4af8-4b10-9b16-700019017acf"), 0, true, new Guid("0cc54ab8-adeb-4a63-948e-d5e65cad8ef4"), new Guid("a0f961c5-7335-4a1c-acae-05d59762b6f0") },
                    { new Guid("f2fc4ea8-dc19-4452-9e4a-b337d3622d40"), 4, false, new Guid("d909bfa4-abbe-4ca0-8a01-1389564d4af9"), new Guid("540e43cb-e960-4a63-88c3-b8671488928f") },
                    { new Guid("c9984f57-8324-4d23-ad1f-f4e0261c4d0a"), 3, false, new Guid("d909bfa4-abbe-4ca0-8a01-1389564d4af9"), new Guid("15aec200-9909-489d-8a7d-3e4aca90e894") },
                    { new Guid("4676dde7-dfa6-4044-a635-b6270ae2c352"), 2, false, new Guid("d909bfa4-abbe-4ca0-8a01-1389564d4af9"), new Guid("ba7a6d10-99c1-406b-8c7e-fcb01de770d6") },
                    { new Guid("aa1e0d6a-e671-42e6-aaa7-49bf79a2cf49"), 1, false, new Guid("d909bfa4-abbe-4ca0-8a01-1389564d4af9"), new Guid("f7abf2bb-e873-403e-bc09-060c245b2fc7") },
                    { new Guid("4e0059e5-01c1-4708-9a91-508201f13791"), 0, true, new Guid("d909bfa4-abbe-4ca0-8a01-1389564d4af9"), new Guid("2c1e4b36-ad95-4aea-833d-58cb25b2e5c1") },
                    { new Guid("46cf1ade-fd0d-4f6c-a729-f683f627f1da"), 4, false, new Guid("abed963d-1cb9-45c7-8715-90ac1d1e5b6f"), new Guid("7a73a81b-7e6c-4089-acd8-0c4eb2faa348") },
                    { new Guid("50f13847-ed21-4964-8488-b45947aa7b0c"), 3, false, new Guid("abed963d-1cb9-45c7-8715-90ac1d1e5b6f"), new Guid("f90548fc-79ad-4ac5-b4b8-3356ebc1ba5b") },
                    { new Guid("b7f84d7e-3d25-4432-a295-6d1f94af0e71"), 2, false, new Guid("abed963d-1cb9-45c7-8715-90ac1d1e5b6f"), new Guid("de79fa7a-819e-4eac-991a-4c1e828fb957") },
                    { new Guid("7f6436c0-cb33-4116-b504-1c85886a2810"), 1, false, new Guid("abed963d-1cb9-45c7-8715-90ac1d1e5b6f"), new Guid("ea5c02c5-e98a-4b28-9497-758c0b0e4290") }
                });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[,]
                {
                    { new Guid("19444af2-74e2-42b6-a76a-c0ac62e54d57"), new Guid("31aee890-3d61-4933-8604-fd6f9324590f"), new DateTime(2021, 5, 25, 0, 57, 44, 640, DateTimeKind.Local).AddTicks(6455), new Guid("8ba5cd31-6d47-4939-8e63-1e1d592eba5b"), null, new DateTime(2021, 5, 25, 0, 57, 44, 640, DateTimeKind.Local).AddTicks(6474), new Guid("579cb650-65e2-4798-be78-19cb27794a6d") },
                    { new Guid("49dd62d6-2efc-4c81-a12b-fe42cd60c3f9"), new Guid("c14d9e43-c684-4e80-b0bd-e166d61d619c"), new DateTime(2021, 5, 25, 0, 57, 44, 640, DateTimeKind.Local).AddTicks(7859), new Guid("e0b18dcf-48e7-4319-a93c-ff24e5f79d0f"), null, new DateTime(2021, 5, 25, 0, 57, 44, 640, DateTimeKind.Local).AddTicks(7860), new Guid("579cb650-65e2-4798-be78-19cb27794a6d") }
                });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[,]
                {
                    { new Guid("6520f0a5-4ce2-4018-a94f-436bf4b95ced"), new Guid("1336c69d-4af8-4b10-9b16-700019017acf"), new DateTime(2021, 5, 25, 0, 57, 44, 640, DateTimeKind.Local).AddTicks(7849), new Guid("0cc54ab8-adeb-4a63-948e-d5e65cad8ef4"), null, new DateTime(2021, 5, 25, 0, 57, 44, 640, DateTimeKind.Local).AddTicks(7854), new Guid("579cb650-65e2-4798-be78-19cb27794a6d") },
                    { new Guid("8faddfbc-25d1-4764-820d-0f9513449837"), new Guid("fde78064-6fa6-4d6c-8e90-24ddcde3012b"), new DateTime(2021, 5, 25, 0, 57, 44, 640, DateTimeKind.Local).AddTicks(7873), new Guid("c5a46c5f-9a81-4ae6-8df3-9da959ddaaa9"), null, new DateTime(2021, 5, 25, 0, 57, 44, 640, DateTimeKind.Local).AddTicks(7874), new Guid("579cb650-65e2-4798-be78-19cb27794a6d") }
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
