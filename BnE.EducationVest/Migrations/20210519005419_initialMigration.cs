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
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    text_content_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_alternative", x => new { x.question_id, x.index });
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

            migrationBuilder.InsertData(
                table: "exam",
                columns: new[] { "id", "created_date", "exam_number", "exam_type", "removed_date", "updated_date" },
                values: new object[,]
                {
                    { new Guid("d07485f8-ef2f-4178-85e8-cbe088b0e28d"), new DateTime(2021, 5, 18, 21, 54, 18, 476, DateTimeKind.Local).AddTicks(2534), 1, 2, null, new DateTime(2021, 5, 18, 21, 54, 18, 476, DateTimeKind.Local).AddTicks(2539) },
                    { new Guid("df2a0ef3-f26c-4442-acb6-a7a4e2e58f9c"), new DateTime(2021, 5, 18, 21, 54, 18, 476, DateTimeKind.Local).AddTicks(6299), 1, 1, null, new DateTime(2021, 5, 18, 21, 54, 18, 476, DateTimeKind.Local).AddTicks(6300) },
                    { new Guid("8be840e3-be84-44c1-a614-abf9e4d86bf8"), new DateTime(2021, 5, 18, 21, 54, 18, 476, DateTimeKind.Local).AddTicks(6308), 2, 1, null, new DateTime(2021, 5, 18, 21, 54, 18, 476, DateTimeKind.Local).AddTicks(6309) }
                });

            migrationBuilder.InsertData(
                table: "incremented_text",
                columns: new[] { "id", "content", "increments" },
                values: new object[,]
                {
                    { new Guid("9f0ae8d9-39ce-42d1-a58c-28a04684e6e7"), "30°", null },
                    { new Guid("86cacd23-80e7-4e6d-9169-7a38e4758a79"), "45°", null },
                    { new Guid("6d15c8d2-5c3b-4180-a8e5-599b9a085ff3"), "22,5°", null },
                    { new Guid("c3e30d0e-dbb5-4b31-88b6-1816465c0e94"), "15°", null },
                    { new Guid("71dd8b0e-9232-4bd3-bae9-251ca26d523e"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("41eec0ba-5fab-4620-8f83-c6aec58a686f"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("0315c0ab-3120-453a-9ab4-ffcbc29f90c1"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("6c08cb1b-6533-4cbe-9465-d0161e54e91b"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("7edd21f5-629f-4f5d-b574-fb21db6c17d3"), "60°", null },
                    { new Guid("bd8803ba-ba25-495c-8c04-3783ff31b233"), "5,34", null },
                    { new Guid("b7dcd9e8-7fc5-4b6b-a5b2-b9dedd1a2f58"), "3,68", null },
                    { new Guid("0c6a95fd-ddf4-407c-a31c-75f0baeaecdb"), "6.62", null },
                    { new Guid("d65d3a17-17cc-406e-ba33-4b5cdb37e993"), "8,32", null },
                    { new Guid("d40bbbaf-db09-426f-b45e-02c449ab856f"), "4,64", null },
                    { new Guid("e6990ea6-23e1-4bac-bbf6-a1651ae2cde9"), "maior que 131", null },
                    { new Guid("c8f4cd07-1bea-4fd3-84cb-cfa17c50c7b9"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("7c98f79e-023b-4a43-a7ea-86c6f9574784"), "menor do que 128.", null },
                    { new Guid("00e6d697-0dc5-421f-bf95-22af74b4a747"), "entre 128 e 129.", null },
                    { new Guid("eec15771-bef4-4fb2-8038-04199c9a2a12"), "entre 129 e 130.", null },
                    { new Guid("42fa4dc6-5564-409d-9b98-3a8480510452"), "45°", null },
                    { new Guid("2c4ed05b-9ba2-4ca5-89a9-1a6059c7a704"), "22,5°", null },
                    { new Guid("9a62e495-d936-47be-9776-11bbd565619a"), "15°", null },
                    { new Guid("63126275-8d0f-491f-9433-2bd6063bb7f1"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("bcc0791c-0f7c-4457-a338-3bba01fb0eb6"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("5af1a9f5-be79-4703-a300-959fa1506299"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("25bc2496-fbb2-4c12-8e7f-9cfdbdeed26c"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("9939396d-78c5-4bdc-a6a2-82d85a69aa65"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("22091b88-0463-4a72-80b9-b04f29f652a9"), "5,34", null },
                    { new Guid("2b3ba25b-60ff-49f1-a45a-d894f05db2a4"), "3,68", null },
                    { new Guid("d924dae7-8b8c-4f95-8a81-ccfb659a9e55"), "6.62", null },
                    { new Guid("9461b339-d713-4369-b920-388a6c05235c"), "8,32", null },
                    { new Guid("34b29994-1994-45bb-82b0-f6245c364c53"), "4,64", null },
                    { new Guid("ba6b5d4c-45fb-4bb2-a42d-a88663d82406"), "maior que 131", null },
                    { new Guid("c1b4c4c0-f95a-4682-b0c8-b2a62cd89342"), "entre 130 e 131.", null },
                    { new Guid("4fc415f7-e6f8-4b0c-95f6-d0ed34d8a3e8"), "entre 130 e 131.", null },
                    { new Guid("4a5a630e-e086-4047-8c9d-f0b7fa84af81"), "entre 129 e 130.", null },
                    { new Guid("b053f9de-aa36-4f51-aa22-1fcbdaa0d47d"), "entre 128 e 129.", null },
                    { new Guid("5743897c-ac4e-4d83-81a7-a83e63b7a65a"), "menor do que 128.", null },
                    { new Guid("bbcf3790-cef7-45cf-b31b-d96d7c01428a"), "entre 128 e 129.", null },
                    { new Guid("576519aa-93bc-472c-971e-a49a576bed78"), "menor do que 128.", null },
                    { new Guid("f0ffd4b9-7697-4b6d-b310-3ae696dc67b1"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("3b1b42f9-dd09-4956-b913-043ca727b8c6"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("a945303d-83b7-432e-bd97-a5e358df463a"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("1585e0ea-b4b7-4064-9d14-36e4117160ee"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("15872782-c08b-4b02-939b-f31afd011f4d"), "30°", null },
                    { new Guid("86fc0059-1fd1-4bf3-9807-5f13c64805b1"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("69e31e80-8b51-439d-a226-15f590ccc0cb"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("3232eeba-9830-4204-bc99-c6b19f672b66"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("db70a537-3831-41ae-ae44-e50e65ffbe0c"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("c945c63c-bdc8-4e68-9d58-6665ef818f11"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("0a400db7-f045-4350-9c03-7b276450d1f8"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("d19beaf4-7317-48da-af1c-374d354bfde4"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("815fc0f6-3d51-4e46-b01d-11b9bc24c9fd"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("9adf8b4c-5d49-4015-a977-2735ec51c4fd"), "entre 130 e 131.", null },
                    { new Guid("5599fcac-fedf-45ce-ba6e-a4c2d638f51a"), "entre 129 e 130.", null },
                    { new Guid("8858dd68-1fe5-4881-9aeb-da469d1bf7c1"), "4,64", null },
                    { new Guid("35932305-358a-481d-8bfd-7caac98bfad7"), "60°", null },
                    { new Guid("348a45e4-9c52-4cf3-b605-2daa8f261762"), "30°", null },
                    { new Guid("649b1cda-57b2-48ac-8972-34055927b95e"), "45°", null },
                    { new Guid("70d23acf-90b0-49cb-8a1b-fc362481fb58"), "22,5°", null },
                    { new Guid("738b87eb-472c-4d80-88b1-6c1975bd435c"), "15°", null },
                    { new Guid("fd22dd33-0a96-4632-b2e4-15f064e0e549"), "maior que 131", null },
                    { new Guid("a6472904-935a-4aef-aa24-bd284837a359"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("30d3064e-2c57-4780-af68-be25310e0e26"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("54dcd02d-9189-466e-acd3-481b1e5bd319"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("b0ebd166-90de-4171-8e33-d9377b92cff1"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("9f43d6eb-df52-4d1e-9298-40cff13fd1c6"), "5,34", null },
                    { new Guid("fddfe007-140e-433c-919b-a88f13beee83"), "3,68", null },
                    { new Guid("f267d363-7880-43ec-a3a2-0f2691f0f6d9"), "6.62", null },
                    { new Guid("37adf8dc-d283-4e14-bf06-f066b685f92c"), "8,32", null },
                    { new Guid("56d1e34d-4581-40bc-848a-285f00669670"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("19dfe1fe-a719-48f8-bc4b-4282e1f73a2f"), "60°", null }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("20e7aac6-8a85-4a6f-8e77-b15ff6a47d81"), new DateTime(2021, 5, 18, 21, 54, 18, 474, DateTimeKind.Local).AddTicks(8889), "Português", null, null, new DateTime(2021, 5, 18, 21, 54, 18, 474, DateTimeKind.Local).AddTicks(8893) },
                    { new Guid("2f07b7bd-2519-4a08-a712-de656d82842e"), new DateTime(2021, 5, 18, 21, 54, 18, 474, DateTimeKind.Local).AddTicks(7665), "Matemática", null, null, new DateTime(2021, 5, 18, 21, 54, 18, 474, DateTimeKind.Local).AddTicks(8127) }
                });

            migrationBuilder.InsertData(
                table: "exam_period",
                columns: new[] { "id", "close_date", "exam_id", "open_date" },
                values: new object[,]
                {
                    { new Guid("b799e2e8-6087-460d-ae8c-032e0d56694f"), new DateTime(2021, 5, 22, 12, 0, 0, 0, DateTimeKind.Local), new Guid("d07485f8-ef2f-4178-85e8-cbe088b0e28d"), new DateTime(2021, 5, 22, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("c30ed310-82f8-468f-9621-7714299c5485"), new DateTime(2021, 5, 23, 12, 0, 0, 0, DateTimeKind.Local), new Guid("d07485f8-ef2f-4178-85e8-cbe088b0e28d"), new DateTime(2021, 5, 23, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("6dc524e3-3872-4b23-8ad8-49d6589e60eb"), new DateTime(2021, 5, 19, 1, 54, 18, 476, DateTimeKind.Local).AddTicks(6274), new Guid("df2a0ef3-f26c-4442-acb6-a7a4e2e58f9c"), new DateTime(2021, 5, 18, 21, 54, 18, 476, DateTimeKind.Local).AddTicks(6274) },
                    { new Guid("74fab709-886d-4077-b55c-3d7e1788d339"), new DateTime(2021, 5, 19, 23, 54, 18, 476, DateTimeKind.Local).AddTicks(6274), new Guid("df2a0ef3-f26c-4442-acb6-a7a4e2e58f9c"), new DateTime(2021, 5, 19, 21, 54, 18, 476, DateTimeKind.Local).AddTicks(6274) },
                    { new Guid("c2e0578d-5ca8-414f-b662-d84c9481ee05"), new DateTime(2021, 5, 16, 23, 54, 18, 476, DateTimeKind.Local).AddTicks(6303), new Guid("8be840e3-be84-44c1-a614-abf9e4d86bf8"), new DateTime(2021, 5, 16, 21, 54, 18, 476, DateTimeKind.Local).AddTicks(6303) },
                    { new Guid("0dd50eb9-472f-4a1f-9e3c-62432ca9cfcb"), new DateTime(2021, 5, 17, 23, 54, 18, 476, DateTimeKind.Local).AddTicks(6303), new Guid("8be840e3-be84-44c1-a614-abf9e4d86bf8"), new DateTime(2021, 5, 17, 21, 54, 18, 476, DateTimeKind.Local).AddTicks(6303) }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("450e09dd-55b4-41d6-b6a9-680b8d973fe2"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(6916), new Guid("d19beaf4-7317-48da-af1c-374d354bfde4"), new Guid("d07485f8-ef2f-4178-85e8-cbe088b0e28d"), 0, null, new Guid("2f07b7bd-2519-4a08-a712-de656d82842e"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(6921) },
                    { new Guid("f506be00-b7f1-4ec2-9a79-5edb17f11631"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9517), new Guid("c945c63c-bdc8-4e68-9d58-6665ef818f11"), new Guid("d07485f8-ef2f-4178-85e8-cbe088b0e28d"), 2, null, new Guid("20e7aac6-8a85-4a6f-8e77-b15ff6a47d81"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9518) },
                    { new Guid("9a36cba4-96fe-4316-9f85-762a8c775eed"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9539), new Guid("3232eeba-9830-4204-bc99-c6b19f672b66"), new Guid("df2a0ef3-f26c-4442-acb6-a7a4e2e58f9c"), 0, null, new Guid("2f07b7bd-2519-4a08-a712-de656d82842e"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9539) },
                    { new Guid("94f24c40-6aa0-4a88-9eec-d80e276878be"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9557), new Guid("815fc0f6-3d51-4e46-b01d-11b9bc24c9fd"), new Guid("df2a0ef3-f26c-4442-acb6-a7a4e2e58f9c"), 2, null, new Guid("20e7aac6-8a85-4a6f-8e77-b15ff6a47d81"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9558) },
                    { new Guid("dbd860c9-520f-4ed9-ab4f-88248e8691fe"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9578), new Guid("1585e0ea-b4b7-4064-9d14-36e4117160ee"), new Guid("8be840e3-be84-44c1-a614-abf9e4d86bf8"), 0, null, new Guid("2f07b7bd-2519-4a08-a712-de656d82842e"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9579) },
                    { new Guid("fa11525e-9295-40d3-928e-fba943ada12b"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9630), new Guid("3b1b42f9-dd09-4956-b913-043ca727b8c6"), new Guid("8be840e3-be84-44c1-a614-abf9e4d86bf8"), 2, null, new Guid("20e7aac6-8a85-4a6f-8e77-b15ff6a47d81"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9631) }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[] { new Guid("1a8d417d-8de5-496f-aa14-169f85509131"), new DateTime(2021, 5, 18, 21, 54, 18, 474, DateTimeKind.Local).AddTicks(8895), "Porcentagem", null, new Guid("2f07b7bd-2519-4a08-a712-de656d82842e"), new DateTime(2021, 5, 18, 21, 54, 18, 474, DateTimeKind.Local).AddTicks(8896) });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "index", "question_id", "is_correct", "text_content_id" },
                values: new object[,]
                {
                    { 1, new Guid("9a36cba4-96fe-4316-9f85-762a8c775eed"), false, new Guid("b053f9de-aa36-4f51-aa22-1fcbdaa0d47d") },
                    { 4, new Guid("9a36cba4-96fe-4316-9f85-762a8c775eed"), false, new Guid("e6990ea6-23e1-4bac-bbf6-a1651ae2cde9") },
                    { 0, new Guid("94f24c40-6aa0-4a88-9eec-d80e276878be"), true, new Guid("6c08cb1b-6533-4cbe-9465-d0161e54e91b") },
                    { 1, new Guid("94f24c40-6aa0-4a88-9eec-d80e276878be"), false, new Guid("c8f4cd07-1bea-4fd3-84cb-cfa17c50c7b9") },
                    { 2, new Guid("94f24c40-6aa0-4a88-9eec-d80e276878be"), false, new Guid("0315c0ab-3120-453a-9ab4-ffcbc29f90c1") },
                    { 3, new Guid("94f24c40-6aa0-4a88-9eec-d80e276878be"), false, new Guid("41eec0ba-5fab-4620-8f83-c6aec58a686f") },
                    { 4, new Guid("94f24c40-6aa0-4a88-9eec-d80e276878be"), false, new Guid("71dd8b0e-9232-4bd3-bae9-251ca26d523e") },
                    { 3, new Guid("9a36cba4-96fe-4316-9f85-762a8c775eed"), false, new Guid("4fc415f7-e6f8-4b0c-95f6-d0ed34d8a3e8") },
                    { 0, new Guid("dbd860c9-520f-4ed9-ab4f-88248e8691fe"), true, new Guid("7c98f79e-023b-4a43-a7ea-86c6f9574784") },
                    { 2, new Guid("dbd860c9-520f-4ed9-ab4f-88248e8691fe"), false, new Guid("eec15771-bef4-4fb2-8038-04199c9a2a12") },
                    { 3, new Guid("dbd860c9-520f-4ed9-ab4f-88248e8691fe"), false, new Guid("c1b4c4c0-f95a-4682-b0c8-b2a62cd89342") },
                    { 4, new Guid("dbd860c9-520f-4ed9-ab4f-88248e8691fe"), false, new Guid("ba6b5d4c-45fb-4bb2-a42d-a88663d82406") },
                    { 0, new Guid("fa11525e-9295-40d3-928e-fba943ada12b"), true, new Guid("9939396d-78c5-4bdc-a6a2-82d85a69aa65") },
                    { 1, new Guid("fa11525e-9295-40d3-928e-fba943ada12b"), false, new Guid("25bc2496-fbb2-4c12-8e7f-9cfdbdeed26c") },
                    { 2, new Guid("fa11525e-9295-40d3-928e-fba943ada12b"), false, new Guid("5af1a9f5-be79-4703-a300-959fa1506299") },
                    { 1, new Guid("dbd860c9-520f-4ed9-ab4f-88248e8691fe"), false, new Guid("00e6d697-0dc5-421f-bf95-22af74b4a747") },
                    { 2, new Guid("9a36cba4-96fe-4316-9f85-762a8c775eed"), false, new Guid("4a5a630e-e086-4047-8c9d-f0b7fa84af81") },
                    { 4, new Guid("fa11525e-9295-40d3-928e-fba943ada12b"), false, new Guid("63126275-8d0f-491f-9433-2bd6063bb7f1") },
                    { 0, new Guid("9a36cba4-96fe-4316-9f85-762a8c775eed"), true, new Guid("5743897c-ac4e-4d83-81a7-a83e63b7a65a") },
                    { 0, new Guid("450e09dd-55b4-41d6-b6a9-680b8d973fe2"), true, new Guid("576519aa-93bc-472c-971e-a49a576bed78") },
                    { 1, new Guid("450e09dd-55b4-41d6-b6a9-680b8d973fe2"), false, new Guid("bbcf3790-cef7-45cf-b31b-d96d7c01428a") },
                    { 3, new Guid("fa11525e-9295-40d3-928e-fba943ada12b"), false, new Guid("bcc0791c-0f7c-4457-a338-3bba01fb0eb6") },
                    { 3, new Guid("450e09dd-55b4-41d6-b6a9-680b8d973fe2"), false, new Guid("9adf8b4c-5d49-4015-a977-2735ec51c4fd") },
                    { 4, new Guid("450e09dd-55b4-41d6-b6a9-680b8d973fe2"), false, new Guid("fd22dd33-0a96-4632-b2e4-15f064e0e549") },
                    { 2, new Guid("450e09dd-55b4-41d6-b6a9-680b8d973fe2"), false, new Guid("5599fcac-fedf-45ce-ba6e-a4c2d638f51a") },
                    { 1, new Guid("f506be00-b7f1-4ec2-9a79-5edb17f11631"), false, new Guid("54dcd02d-9189-466e-acd3-481b1e5bd319") },
                    { 2, new Guid("f506be00-b7f1-4ec2-9a79-5edb17f11631"), false, new Guid("56d1e34d-4581-40bc-848a-285f00669670") },
                    { 3, new Guid("f506be00-b7f1-4ec2-9a79-5edb17f11631"), false, new Guid("a6472904-935a-4aef-aa24-bd284837a359") },
                    { 4, new Guid("f506be00-b7f1-4ec2-9a79-5edb17f11631"), false, new Guid("30d3064e-2c57-4780-af68-be25310e0e26") },
                    { 0, new Guid("f506be00-b7f1-4ec2-9a79-5edb17f11631"), true, new Guid("b0ebd166-90de-4171-8e33-d9377b92cff1") }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("8634eacc-be4a-4b33-a1cc-e846853b6388"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9640), new Guid("f0ffd4b9-7697-4b6d-b310-3ae696dc67b1"), new Guid("8be840e3-be84-44c1-a614-abf9e4d86bf8"), 3, null, new Guid("1a8d417d-8de5-496f-aa14-169f85509131"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9641) },
                    { new Guid("48586167-2415-41da-8974-f19b66691b16"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9620), new Guid("a945303d-83b7-432e-bd97-a5e358df463a"), new Guid("8be840e3-be84-44c1-a614-abf9e4d86bf8"), 1, null, new Guid("1a8d417d-8de5-496f-aa14-169f85509131"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9621) },
                    { new Guid("0d00941e-9cfe-4e46-9132-72a6af7b6639"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9568), new Guid("86fc0059-1fd1-4bf3-9807-5f13c64805b1"), new Guid("df2a0ef3-f26c-4442-acb6-a7a4e2e58f9c"), 3, null, new Guid("1a8d417d-8de5-496f-aa14-169f85509131"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9569) },
                    { new Guid("31e7a721-34b7-45ae-8eeb-b879582ec8e4"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9547), new Guid("69e31e80-8b51-439d-a226-15f590ccc0cb"), new Guid("df2a0ef3-f26c-4442-acb6-a7a4e2e58f9c"), 1, null, new Guid("1a8d417d-8de5-496f-aa14-169f85509131"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9548) },
                    { new Guid("da26c9ed-1425-48a3-9bfe-7675ae3243e7"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9528), new Guid("db70a537-3831-41ae-ae44-e50e65ffbe0c"), new Guid("d07485f8-ef2f-4178-85e8-cbe088b0e28d"), 3, null, new Guid("1a8d417d-8de5-496f-aa14-169f85509131"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9529) },
                    { new Guid("5e455d9f-a60a-47e8-b71f-852469e0d2e9"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9496), new Guid("0a400db7-f045-4350-9c03-7b276450d1f8"), new Guid("d07485f8-ef2f-4178-85e8-cbe088b0e28d"), 1, null, new Guid("1a8d417d-8de5-496f-aa14-169f85509131"), new DateTime(2021, 5, 18, 21, 54, 18, 475, DateTimeKind.Local).AddTicks(9502) }
                });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "index", "question_id", "is_correct", "text_content_id" },
                values: new object[,]
                {
                    { 0, new Guid("5e455d9f-a60a-47e8-b71f-852469e0d2e9"), true, new Guid("8858dd68-1fe5-4881-9aeb-da469d1bf7c1") },
                    { 2, new Guid("8634eacc-be4a-4b33-a1cc-e846853b6388"), false, new Guid("42fa4dc6-5564-409d-9b98-3a8480510452") },
                    { 1, new Guid("8634eacc-be4a-4b33-a1cc-e846853b6388"), false, new Guid("2c4ed05b-9ba2-4ca5-89a9-1a6059c7a704") },
                    { 0, new Guid("8634eacc-be4a-4b33-a1cc-e846853b6388"), true, new Guid("9a62e495-d936-47be-9776-11bbd565619a") },
                    { 4, new Guid("48586167-2415-41da-8974-f19b66691b16"), false, new Guid("22091b88-0463-4a72-80b9-b04f29f652a9") },
                    { 3, new Guid("48586167-2415-41da-8974-f19b66691b16"), false, new Guid("2b3ba25b-60ff-49f1-a45a-d894f05db2a4") },
                    { 2, new Guid("48586167-2415-41da-8974-f19b66691b16"), false, new Guid("d924dae7-8b8c-4f95-8a81-ccfb659a9e55") },
                    { 1, new Guid("48586167-2415-41da-8974-f19b66691b16"), false, new Guid("9461b339-d713-4369-b920-388a6c05235c") },
                    { 0, new Guid("48586167-2415-41da-8974-f19b66691b16"), true, new Guid("34b29994-1994-45bb-82b0-f6245c364c53") },
                    { 4, new Guid("0d00941e-9cfe-4e46-9132-72a6af7b6639"), false, new Guid("7edd21f5-629f-4f5d-b574-fb21db6c17d3") },
                    { 3, new Guid("0d00941e-9cfe-4e46-9132-72a6af7b6639"), false, new Guid("9f0ae8d9-39ce-42d1-a58c-28a04684e6e7") },
                    { 2, new Guid("0d00941e-9cfe-4e46-9132-72a6af7b6639"), false, new Guid("86cacd23-80e7-4e6d-9169-7a38e4758a79") },
                    { 1, new Guid("0d00941e-9cfe-4e46-9132-72a6af7b6639"), false, new Guid("6d15c8d2-5c3b-4180-a8e5-599b9a085ff3") },
                    { 0, new Guid("0d00941e-9cfe-4e46-9132-72a6af7b6639"), true, new Guid("c3e30d0e-dbb5-4b31-88b6-1816465c0e94") },
                    { 4, new Guid("31e7a721-34b7-45ae-8eeb-b879582ec8e4"), false, new Guid("bd8803ba-ba25-495c-8c04-3783ff31b233") },
                    { 3, new Guid("31e7a721-34b7-45ae-8eeb-b879582ec8e4"), false, new Guid("b7dcd9e8-7fc5-4b6b-a5b2-b9dedd1a2f58") },
                    { 2, new Guid("31e7a721-34b7-45ae-8eeb-b879582ec8e4"), false, new Guid("0c6a95fd-ddf4-407c-a31c-75f0baeaecdb") },
                    { 1, new Guid("31e7a721-34b7-45ae-8eeb-b879582ec8e4"), false, new Guid("d65d3a17-17cc-406e-ba33-4b5cdb37e993") },
                    { 0, new Guid("31e7a721-34b7-45ae-8eeb-b879582ec8e4"), true, new Guid("d40bbbaf-db09-426f-b45e-02c449ab856f") },
                    { 4, new Guid("da26c9ed-1425-48a3-9bfe-7675ae3243e7"), false, new Guid("35932305-358a-481d-8bfd-7caac98bfad7") },
                    { 3, new Guid("da26c9ed-1425-48a3-9bfe-7675ae3243e7"), false, new Guid("348a45e4-9c52-4cf3-b605-2daa8f261762") },
                    { 2, new Guid("da26c9ed-1425-48a3-9bfe-7675ae3243e7"), false, new Guid("649b1cda-57b2-48ac-8972-34055927b95e") },
                    { 1, new Guid("da26c9ed-1425-48a3-9bfe-7675ae3243e7"), false, new Guid("70d23acf-90b0-49cb-8a1b-fc362481fb58") },
                    { 0, new Guid("da26c9ed-1425-48a3-9bfe-7675ae3243e7"), true, new Guid("738b87eb-472c-4d80-88b1-6c1975bd435c") },
                    { 4, new Guid("5e455d9f-a60a-47e8-b71f-852469e0d2e9"), false, new Guid("9f43d6eb-df52-4d1e-9298-40cff13fd1c6") },
                    { 3, new Guid("5e455d9f-a60a-47e8-b71f-852469e0d2e9"), false, new Guid("fddfe007-140e-433c-919b-a88f13beee83") },
                    { 2, new Guid("5e455d9f-a60a-47e8-b71f-852469e0d2e9"), false, new Guid("f267d363-7880-43ec-a3a2-0f2691f0f6d9") },
                    { 1, new Guid("5e455d9f-a60a-47e8-b71f-852469e0d2e9"), false, new Guid("37adf8dc-d283-4e14-bf06-f066b685f92c") },
                    { 3, new Guid("8634eacc-be4a-4b33-a1cc-e846853b6388"), false, new Guid("15872782-c08b-4b02-939b-f31afd011f4d") },
                    { 4, new Guid("8634eacc-be4a-4b33-a1cc-e846853b6388"), false, new Guid("19dfe1fe-a719-48f8-bc4b-4282e1f73a2f") }
                });

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
                name: "ix_subject_subject_father_id",
                table: "subject",
                column: "subject_father_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alternative");

            migrationBuilder.DropTable(
                name: "exam_period");

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
