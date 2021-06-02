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
                    exam_model = table.Column<int>(type: "integer", nullable: false),
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
                    cognito_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_type = table.Column<int>(type: "integer", nullable: false),
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
                    key = table.Column<string>(type: "varchar(30)", nullable: true),
                    label = table.Column<string>(type: "varchar(50)", nullable: true),
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
                name: "supporting_text",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    content_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supporting_text", x => x.id);
                    table.ForeignKey(
                        name: "fk_supporting_text_incremented_texts_content_id",
                        column: x => x.content_id,
                        principalTable: "incremented_text",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "external_user_profile",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    expected_college = table.Column<string>(type: "varchar(30)", nullable: true),
                    expected_course = table.Column<string>(type: "varchar(100)", nullable: true),
                    actual_occupation = table.Column<string>(type: "varchar(100)", nullable: true),
                    actual_college = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    removed_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_external_user_profile", x => x.id);
                    table.ForeignKey(
                        name: "fk_external_user_profile_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
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
                    supporting_text_id = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.ForeignKey(
                        name: "fk_question_supporting_text_supporting_text_id",
                        column: x => x.supporting_text_id,
                        principalTable: "supporting_text",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                columns: new[] { "id", "created_date", "exam_model", "exam_number", "exam_type", "removed_date", "updated_date" },
                values: new object[,]
                {
                    { new Guid("2044520f-1f88-464d-840e-af51ab9b0a22"), new DateTime(2021, 6, 2, 4, 0, 4, 880, DateTimeKind.Local).AddTicks(5318), 0, 1, 0, null, new DateTime(2021, 6, 2, 4, 0, 4, 880, DateTimeKind.Local).AddTicks(5326) },
                    { new Guid("438fa0cd-85f3-4e53-9973-dac65030690e"), new DateTime(2021, 6, 2, 4, 0, 4, 880, DateTimeKind.Local).AddTicks(8665), 1, 1, 1, null, new DateTime(2021, 6, 2, 4, 0, 4, 880, DateTimeKind.Local).AddTicks(8667) },
                    { new Guid("57bc14e2-3754-415a-922f-73f5adefd75a"), new DateTime(2021, 6, 2, 4, 0, 4, 880, DateTimeKind.Local).AddTicks(8693), 1, 2, 1, null, new DateTime(2021, 6, 2, 4, 0, 4, 880, DateTimeKind.Local).AddTicks(8694) }
                });

            migrationBuilder.InsertData(
                table: "incremented_text",
                columns: new[] { "id", "content", "increments" },
                values: new object[,]
                {
                    { new Guid("e30e13dc-2a53-4d7e-bb1e-2c3d6ef647a7"), "8,32", null },
                    { new Guid("5e7a2729-d079-47b2-88bf-28af1f4d46da"), "4,64", null },
                    { new Guid("7356e067-b4a8-4cce-a33d-7c8b31697b2b"), "maior que 131", null },
                    { new Guid("866c9c62-8863-476a-b88c-57341f2ff87f"), "entre 130 e 131.", null },
                    { new Guid("48de392b-cbe3-4c4a-9501-d33a7c362d4b"), "entre 129 e 130.", null },
                    { new Guid("81679a7b-823a-4fc5-bea6-0c51c3945941"), "entre 128 e 129.", null },
                    { new Guid("46777885-c09c-4cc8-b78a-f2dab121d85a"), "menor do que 128.", null },
                    { new Guid("c1b529a6-01b1-4362-8b30-2a77694dac5e"), "60°", null },
                    { new Guid("8ff80225-fa4b-4113-afe1-5ffb2f64000f"), "30°", null },
                    { new Guid("aabfc6cc-79af-46b1-94fc-177e9d455e23"), "45°", null },
                    { new Guid("42648fbf-b7ba-4a67-8a0b-68332c136d15"), "Testeee2", null },
                    { new Guid("12ec7c9f-29d1-4861-a14f-49fa2fcd87aa"), "Teste", null },
                    { new Guid("8d420653-ba07-4266-944f-2323cffea4b2"), "60°", null },
                    { new Guid("63ef1b9e-f4b7-4d49-a563-9c94aaa65461"), "30°", null },
                    { new Guid("71a20f8f-9c29-4b9b-b83d-63bf6e6f14dc"), "45°", null },
                    { new Guid("5d7445b7-bfbb-4d76-851a-994ba93cdb7d"), "22,5°", null },
                    { new Guid("44a5f6c8-1d84-40d0-ac6e-5a4bac966d0a"), "15°", null },
                    { new Guid("d5c71fcc-7595-4eed-b023-1eef0d219b8b"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("e6797bb4-d1f2-4e8e-ab25-7bdef9eda5e0"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("0e717910-6574-4737-b539-470c09effe04"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("d5656b57-1138-4fb4-bfb0-b10c7f1c0a36"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("80db8ef3-dddf-42f8-ad17-0daacb5595bd"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("763fefb7-defe-4df6-bf02-0ca3128b05be"), "6.62", null },
                    { new Guid("bf7d1904-f468-442c-816e-069c7bac6211"), "3,68", null },
                    { new Guid("d95cb5fe-2759-4bae-bca5-9558db27671e"), "5,34", null },
                    { new Guid("09674527-54c1-4da9-8f84-d783f7ce3157"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("e5d2897f-b5ae-4063-9d7b-0eb6956f887f"), "TEXTO DE APOIO SIMPLES SEM INCREMENTO", null },
                    { new Guid("00c22dbe-1e66-44ee-9208-afdb9dc8cd64"), "TEXTO DE APOIO SIMPLES SEM INCREMENTO", null },
                    { new Guid("bf482ae5-657b-458d-8616-80608e7f3764"), "TEXTO DE APOIO DE PORTUGUES COM IMAGEM \r\n {0}", "[{\"Index\":0,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("fba62d4f-f02b-4dc4-841e-75f2536f2301"), "TEXTO DE APOIO DE PORTUGUES COM IMAGEM \r\n {0}", "[{\"Index\":0,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("30b2e062-75b4-4802-867b-61a10f24d8af"), "TEXTO DE APOIO DE PORTUGUES COM IMAGEM \r\n {0}", "[{\"Index\":0,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("f8d7c69a-30df-4e0d-8ebd-906ef699dabc"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("7c23e341-f979-4139-ba6f-9a05b5155e12"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("c5df9feb-3f7e-4155-a932-3428908063ec"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("4e0fefeb-cef3-4888-acdc-429b7032c9eb"), "60°", null },
                    { new Guid("e18c5829-d07c-4d08-9679-4fedb7396445"), "30°", null },
                    { new Guid("47471283-2f44-4713-bac8-2092749d1b5a"), "5,34", null },
                    { new Guid("c7f58e2f-95d8-4439-8b22-a8a3f9b3f9f8"), "45°", null },
                    { new Guid("f7641635-a1e7-4822-bc00-eb6510e2204e"), "Teste", null },
                    { new Guid("ad13ce8d-70d2-4f47-ae68-83d7fffa4335"), "60°", null },
                    { new Guid("66293c79-9cda-447d-845b-632d13f47c7c"), "30°", null },
                    { new Guid("e9f5cec3-5f5a-4302-a714-fcec98ab7f91"), "45°", null },
                    { new Guid("e0930762-2cf6-490f-b8f9-23feb5e5f09f"), "22,5°", null },
                    { new Guid("ac7cd3b2-75a0-4f8b-8f60-c543ecd1ce7c"), "15°", null },
                    { new Guid("a12e0bbd-c6e1-4fa4-9f51-96a87f2bc454"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("f0507a87-4242-49c3-b93c-7785e5a04a55"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("e0832360-6da9-4b67-beb4-670bc59326ba"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("8cd8aee0-d921-44dd-a5c7-9335b4ad99f8"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("37347f59-def7-4c57-ad85-fb80395a1355"), "Testeee2", null },
                    { new Guid("fc35abaf-00c0-4272-8020-671365a6310f"), "3,68", null },
                    { new Guid("0f6842a1-bb29-474f-a83e-9158687fdd55"), "8,32", null },
                    { new Guid("d46ba576-2449-47cd-bdc1-753ce26340bd"), "TEXTO DE APOIO SIMPLES SEM INCREMENTO", null },
                    { new Guid("eed7fd55-abe3-49ee-9079-d869d7096bc2"), "4,64", null },
                    { new Guid("b807c4c3-15c9-4a0c-a784-390b32932c3f"), "maior que 131", null },
                    { new Guid("69e868f6-aed1-4dd0-9d75-f33a03df4d91"), "entre 130 e 131.", null },
                    { new Guid("7c59e70e-40f0-4de7-9ef1-c5231041de2b"), "entre 129 e 130.", null },
                    { new Guid("9fbca7be-1808-49dc-ae42-bcc2c2617808"), "entre 128 e 129.", null },
                    { new Guid("186aa60f-cae8-4915-9d97-f3e4ae1ad268"), "menor do que 128.", null },
                    { new Guid("e896ddbb-5660-4abc-9b72-e412be12a828"), "Enunciado teste com equacao {0} e imagem:  \r\n{1}\r\n  para teste", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("3ea9c671-9ed9-479c-ae10-4dd5a6fa44ae"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("4da3e0f7-ff4d-4697-80f2-a038d72d2b38"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("ee608d93-488a-4338-b60d-a60e6e697dc4"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("164ad745-cc07-4d7c-bb33-98e2ec884aeb"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("5b2c703e-0585-401c-b8dc-7b04c062f812"), "Enunciado teste com equacao {0} e imagem:  \r\n{1}\r\n  para teste", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("cfe939ea-3adb-4263-b3dc-c7b7d869aaef"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("b3ad3bc2-3afa-4e1a-b489-5ebf4fffc07a"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("b2f7669b-c6cf-48af-a546-1e44e24bc67f"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("8f1ae030-1f68-402f-be1f-5b0296d98070"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("79d51f9f-1190-44b7-ad96-25e78eae797d"), "Enunciado teste com equacao {0} e imagem:  \r\n{1}\r\n  para teste", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("9cb1cf9c-e58b-491e-9ef6-ba3123221f1f"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("d496ca53-8ad0-4c55-b465-0ae0af6e1cff"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("b9b4a14a-5952-4984-a1da-cb33c90314c5"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("e21fdd35-5933-4494-adbe-71d864828566"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("9a9fdf21-53e5-4c9f-910a-0162677cee0d"), "6.62", null },
                    { new Guid("4e5d4da6-057b-4d40-8c98-931a94d25a7e"), "6.62", null },
                    { new Guid("1ca5e685-08a0-4e22-8573-a7271d7c2639"), "8,32", null },
                    { new Guid("6de18948-4d3c-4ac5-b546-8b542e35ea28"), "5,34", null },
                    { new Guid("204925de-ddb2-441c-93af-78e17792bd7c"), "4,64", null },
                    { new Guid("baf772a2-c599-4a65-9f0a-35b3223d89fe"), "maior que 131", null },
                    { new Guid("3397ce40-1855-4706-a602-9aa7bbb4d0c2"), "entre 130 e 131.", null },
                    { new Guid("a171f801-f1d6-4af7-877d-b712dcf77380"), "entre 129 e 130.", null },
                    { new Guid("24548991-e563-4a1f-a4d2-a65e53f218e3"), "entre 128 e 129.", null },
                    { new Guid("80c0165e-29cf-446a-b03b-8220f36d6c7c"), "menor do que 128.", null },
                    { new Guid("bc6094f8-60f0-4cd2-b43e-550f8e8aa9de"), "60°", null },
                    { new Guid("5ddb384f-4562-433f-aba5-2e4a0a6e5cb2"), "30°", null },
                    { new Guid("9fcc0550-7bb5-4325-a5cc-5daa0659acf6"), "3,68", null },
                    { new Guid("0cdc9f25-c035-4c5e-96fa-fec903a716cf"), "Testeee2", null },
                    { new Guid("f8c652b6-4dd9-495d-8439-f72c0217c610"), "45°", null },
                    { new Guid("996417e0-c5b4-4a56-9b80-82d53836eedc"), "60°", null },
                    { new Guid("50ae137b-df3e-47d7-baac-11f0f7294244"), "30°", null },
                    { new Guid("c73a60bc-4ea5-43b2-9b13-406e9e3d447b"), "45°", null },
                    { new Guid("04454e34-cb66-4aa3-ac39-b270011092bc"), "22,5°", null },
                    { new Guid("8f4098cc-37d4-4d02-962c-2b5056ba508d"), "15°", null },
                    { new Guid("989ade4f-7d7a-4c98-8838-c65f83a6d8f0"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("c7ecc798-2df4-46db-ad87-984c475b3e57"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("438d4822-926e-4782-bfdf-9c78c6f1969c"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("ec856314-2737-43f3-bc75-0947cea6943f"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("f9522545-d7d5-4428-91e3-613a6e02acc0"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("f5e7efe5-97ec-45ca-9052-45f6373941a5"), "Teste", null }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("b0bc0acc-5e66-44a7-8ff7-ebfcee7b84e3"), new DateTime(2021, 6, 2, 4, 0, 4, 870, DateTimeKind.Local).AddTicks(3482), "Polinômios", null, null, new DateTime(2021, 6, 2, 4, 0, 4, 870, DateTimeKind.Local).AddTicks(3483) },
                    { new Guid("6d20cf15-db3d-46a7-af5b-2e3be6d66b82"), new DateTime(2021, 6, 2, 4, 0, 4, 870, DateTimeKind.Local).AddTicks(3472), "Português", null, null, new DateTime(2021, 6, 2, 4, 0, 4, 870, DateTimeKind.Local).AddTicks(3476) },
                    { new Guid("8c1830ed-d266-4063-b37d-030fe357755c"), new DateTime(2021, 6, 2, 4, 0, 4, 870, DateTimeKind.Local).AddTicks(2140), "Matemática", null, null, new DateTime(2021, 6, 2, 4, 0, 4, 870, DateTimeKind.Local).AddTicks(2611) }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "birth_date", "cognito_user_id", "created_date", "email", "gender", "name", "phone_number", "removed_date", "updated_date", "user_type", "address.cep", "address.city", "address.neighborhood", "address.state", "address.street" },
                values: new object[] { new Guid("a517dc0c-a7ba-493d-ae81-9d988333f9d5"), new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e32ca6c-2a66-4ea6-a0c4-cf655dab5191"), new DateTime(2021, 6, 2, 4, 0, 4, 879, DateTimeKind.Local).AddTicks(6288), "sacchitiellogiovanni@gmail.com", "Masculino", "Giovanni Sacchitiello", "11991392711", null, new DateTime(2021, 6, 2, 4, 0, 4, 879, DateTimeKind.Local).AddTicks(6315), 0, "03320020", "São Paulo", "Carrão", "SP", "Rua antonio ciucio" });

            migrationBuilder.InsertData(
                table: "exam_period",
                columns: new[] { "id", "close_date", "exam_id", "open_date" },
                values: new object[,]
                {
                    { new Guid("cfb70065-dbd0-4649-87e9-e9c5f39971ff"), new DateTime(2021, 6, 6, 12, 0, 0, 0, DateTimeKind.Local), new Guid("2044520f-1f88-464d-840e-af51ab9b0a22"), new DateTime(2021, 6, 6, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("0506a502-1a23-4ca8-af49-13afccde505b"), new DateTime(2021, 6, 7, 12, 0, 0, 0, DateTimeKind.Local), new Guid("2044520f-1f88-464d-840e-af51ab9b0a22"), new DateTime(2021, 6, 7, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("9621f4d9-edd5-4f86-a5d2-994481657e45"), new DateTime(2021, 6, 2, 8, 0, 4, 880, DateTimeKind.Local).AddTicks(8631), new Guid("438fa0cd-85f3-4e53-9973-dac65030690e"), new DateTime(2021, 6, 2, 4, 0, 4, 880, DateTimeKind.Local).AddTicks(8631) },
                    { new Guid("83552556-e30d-44ef-bc0b-09645c083265"), new DateTime(2021, 6, 3, 6, 0, 4, 880, DateTimeKind.Local).AddTicks(8631), new Guid("438fa0cd-85f3-4e53-9973-dac65030690e"), new DateTime(2021, 6, 3, 4, 0, 4, 880, DateTimeKind.Local).AddTicks(8631) },
                    { new Guid("9c2be7ef-e099-4f8d-9ddb-00f7a786d5fb"), new DateTime(2021, 5, 31, 6, 0, 4, 880, DateTimeKind.Local).AddTicks(8669), new Guid("57bc14e2-3754-415a-922f-73f5adefd75a"), new DateTime(2021, 5, 31, 4, 0, 4, 880, DateTimeKind.Local).AddTicks(8669) },
                    { new Guid("9d6d8b9e-4787-40c8-8e70-c086c7f536fe"), new DateTime(2021, 6, 1, 6, 0, 4, 880, DateTimeKind.Local).AddTicks(8669), new Guid("57bc14e2-3754-415a-922f-73f5adefd75a"), new DateTime(2021, 6, 1, 4, 0, 4, 880, DateTimeKind.Local).AddTicks(8669) }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "supporting_text_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("e7dff455-1e0e-4468-a2d5-8c109b46895e"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7626), new Guid("5b2c703e-0585-401c-b8dc-7b04c062f812"), new Guid("438fa0cd-85f3-4e53-9973-dac65030690e"), 4, null, new Guid("b0bc0acc-5e66-44a7-8ff7-ebfcee7b84e3"), null, new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7627) },
                    { new Guid("1ec91b63-b754-4dd1-afb3-e1facf6f8c8e"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7790), new Guid("e896ddbb-5660-4abc-9b72-e412be12a828"), new Guid("57bc14e2-3754-415a-922f-73f5adefd75a"), 4, null, new Guid("b0bc0acc-5e66-44a7-8ff7-ebfcee7b84e3"), null, new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7791) },
                    { new Guid("f805d0ad-072e-4d23-9905-d82f068ab320"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7512), new Guid("79d51f9f-1190-44b7-ad96-25e78eae797d"), new Guid("2044520f-1f88-464d-840e-af51ab9b0a22"), 4, null, new Guid("b0bc0acc-5e66-44a7-8ff7-ebfcee7b84e3"), null, new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7513) }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[] { new Guid("0c44280a-5a46-4cb5-872c-a697be71e0f6"), new DateTime(2021, 6, 2, 4, 0, 4, 870, DateTimeKind.Local).AddTicks(3479), "Porcentagem", null, new Guid("8c1830ed-d266-4063-b37d-030fe357755c"), new DateTime(2021, 6, 2, 4, 0, 4, 870, DateTimeKind.Local).AddTicks(3480) });

            migrationBuilder.InsertData(
                table: "supporting_text",
                columns: new[] { "id", "content_id" },
                values: new object[,]
                {
                    { new Guid("eed3d8da-1740-4ab3-82bf-746cbe776b9e"), new Guid("e5d2897f-b5ae-4063-9d7b-0eb6956f887f") },
                    { new Guid("c4d41ef0-aebe-48d9-8bf1-62a4ef9b0674"), new Guid("c5df9feb-3f7e-4155-a932-3428908063ec") },
                    { new Guid("eddccb1a-50fa-4bf0-9c2d-e2a760a9113c"), new Guid("7c23e341-f979-4139-ba6f-9a05b5155e12") },
                    { new Guid("f6ad9e3b-8fac-43a9-b8d2-2a5b0e9219f8"), new Guid("f8d7c69a-30df-4e0d-8ebd-906ef699dabc") },
                    { new Guid("823d3ba8-8bb2-4bb3-9513-ed7f923599dd"), new Guid("30b2e062-75b4-4802-867b-61a10f24d8af") },
                    { new Guid("4f0082be-c93e-4467-8e6e-6a19cc8cf20a"), new Guid("fba62d4f-f02b-4dc4-841e-75f2536f2301") },
                    { new Guid("9f6294a3-b61c-4557-8191-3a95e74f04bd"), new Guid("bf482ae5-657b-458d-8616-80608e7f3764") },
                    { new Guid("c4994594-f5e3-48b4-9a1c-40d149f62259"), new Guid("00c22dbe-1e66-44ee-9208-afdb9dc8cd64") },
                    { new Guid("82cbfeb4-6478-4235-b0d5-14aa107dbf0e"), new Guid("d46ba576-2449-47cd-bdc1-753ce26340bd") }
                });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("130b9b93-7b6a-46b8-9f96-74ba11e81fc4"), 0, true, new Guid("f805d0ad-072e-4d23-9905-d82f068ab320"), new Guid("f5e7efe5-97ec-45ca-9052-45f6373941a5") },
                    { new Guid("0bb73dda-1d0c-4317-aaad-74a460af84e1"), 4, false, new Guid("1ec91b63-b754-4dd1-afb3-e1facf6f8c8e"), new Guid("4e0fefeb-cef3-4888-acdc-429b7032c9eb") },
                    { new Guid("4401aacb-b2b2-44b2-a658-6dab2e1c2d82"), 2, false, new Guid("1ec91b63-b754-4dd1-afb3-e1facf6f8c8e"), new Guid("c7f58e2f-95d8-4439-8b22-a8a3f9b3f9f8") },
                    { new Guid("642cd140-71d5-4e7d-aee9-402d7dbaefa9"), 1, false, new Guid("1ec91b63-b754-4dd1-afb3-e1facf6f8c8e"), new Guid("37347f59-def7-4c57-ad85-fb80395a1355") },
                    { new Guid("515ba07c-fdb9-47cc-859f-4b8794be04f4"), 0, true, new Guid("1ec91b63-b754-4dd1-afb3-e1facf6f8c8e"), new Guid("f7641635-a1e7-4822-bc00-eb6510e2204e") },
                    { new Guid("af7800aa-6670-41da-9139-5d6e56a89909"), 4, false, new Guid("e7dff455-1e0e-4468-a2d5-8c109b46895e"), new Guid("c1b529a6-01b1-4362-8b30-2a77694dac5e") },
                    { new Guid("b8f1d92f-a188-44f3-b452-30bf0c92ddad"), 3, false, new Guid("e7dff455-1e0e-4468-a2d5-8c109b46895e"), new Guid("8ff80225-fa4b-4113-afe1-5ffb2f64000f") },
                    { new Guid("46d50daf-fc9e-4414-bf93-b02d16bfe666"), 3, false, new Guid("1ec91b63-b754-4dd1-afb3-e1facf6f8c8e"), new Guid("e18c5829-d07c-4d08-9679-4fedb7396445") },
                    { new Guid("fdc30685-d53b-4640-9a9b-2f033660cf4d"), 1, false, new Guid("e7dff455-1e0e-4468-a2d5-8c109b46895e"), new Guid("42648fbf-b7ba-4a67-8a0b-68332c136d15") },
                    { new Guid("473c0534-e605-4293-90e8-80c145df5f98"), 0, true, new Guid("e7dff455-1e0e-4468-a2d5-8c109b46895e"), new Guid("12ec7c9f-29d1-4861-a14f-49fa2fcd87aa") },
                    { new Guid("00fba0c4-ebd8-438c-ad72-8ad0878a0bb7"), 4, false, new Guid("f805d0ad-072e-4d23-9905-d82f068ab320"), new Guid("bc6094f8-60f0-4cd2-b43e-550f8e8aa9de") },
                    { new Guid("788f47d3-9205-4231-97dd-246af7be885b"), 3, false, new Guid("f805d0ad-072e-4d23-9905-d82f068ab320"), new Guid("5ddb384f-4562-433f-aba5-2e4a0a6e5cb2") },
                    { new Guid("9dd72882-ee6a-4c09-be6e-e0ec6af2bb9b"), 2, false, new Guid("f805d0ad-072e-4d23-9905-d82f068ab320"), new Guid("f8c652b6-4dd9-495d-8439-f72c0217c610") },
                    { new Guid("454102c4-3a0a-4aed-9a6d-6774653601dd"), 1, false, new Guid("f805d0ad-072e-4d23-9905-d82f068ab320"), new Guid("0cdc9f25-c035-4c5e-96fa-fec903a716cf") },
                    { new Guid("661b622e-2fb4-463c-8bfc-3c0a0abdb397"), 2, false, new Guid("e7dff455-1e0e-4468-a2d5-8c109b46895e"), new Guid("aabfc6cc-79af-46b1-94fc-177e9d455e23") }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "supporting_text_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("45595653-f4c8-4479-a0c6-e54d1e5dd5ec"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7656), new Guid("ee608d93-488a-4338-b60d-a60e6e697dc4"), new Guid("57bc14e2-3754-415a-922f-73f5adefd75a"), 1, null, new Guid("0c44280a-5a46-4cb5-872c-a697be71e0f6"), new Guid("82cbfeb4-6478-4235-b0d5-14aa107dbf0e"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7657) },
                    { new Guid("118d4574-a027-4f8b-8466-41aac758b0d9"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7640), new Guid("164ad745-cc07-4d7c-bb33-98e2ec884aeb"), new Guid("57bc14e2-3754-415a-922f-73f5adefd75a"), 0, null, new Guid("8c1830ed-d266-4063-b37d-030fe357755c"), new Guid("82cbfeb4-6478-4235-b0d5-14aa107dbf0e"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7641) },
                    { new Guid("3ff49be4-576a-492f-932e-8d106a9aed2b"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7613), new Guid("cfe939ea-3adb-4263-b3dc-c7b7d869aaef"), new Guid("438fa0cd-85f3-4e53-9973-dac65030690e"), 3, null, new Guid("0c44280a-5a46-4cb5-872c-a697be71e0f6"), new Guid("eed3d8da-1740-4ab3-82bf-746cbe776b9e"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7614) },
                    { new Guid("dfdfadf1-24d4-42e5-a58e-1b09f31e47cc"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7584), new Guid("b2f7669b-c6cf-48af-a546-1e44e24bc67f"), new Guid("438fa0cd-85f3-4e53-9973-dac65030690e"), 1, null, new Guid("0c44280a-5a46-4cb5-872c-a697be71e0f6"), new Guid("eed3d8da-1740-4ab3-82bf-746cbe776b9e"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7586) },
                    { new Guid("9e663260-aee7-489c-8ca3-b5ac576d1520"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7498), new Guid("9cb1cf9c-e58b-491e-9ef6-ba3123221f1f"), new Guid("2044520f-1f88-464d-840e-af51ab9b0a22"), 3, null, new Guid("0c44280a-5a46-4cb5-872c-a697be71e0f6"), new Guid("c4994594-f5e3-48b4-9a1c-40d149f62259"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7499) },
                    { new Guid("bd1ad17e-fa41-4fff-8549-d316aa1f4419"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7483), new Guid("d496ca53-8ad0-4c55-b465-0ae0af6e1cff"), new Guid("2044520f-1f88-464d-840e-af51ab9b0a22"), 2, null, new Guid("6d20cf15-db3d-46a7-af5b-2e3be6d66b82"), new Guid("823d3ba8-8bb2-4bb3-9513-ed7f923599dd"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7484) },
                    { new Guid("58275251-b6d9-4933-9ad8-b7124b0b457a"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7599), new Guid("b3ad3bc2-3afa-4e1a-b489-5ebf4fffc07a"), new Guid("438fa0cd-85f3-4e53-9973-dac65030690e"), 2, null, new Guid("6d20cf15-db3d-46a7-af5b-2e3be6d66b82"), new Guid("4f0082be-c93e-4467-8e6e-6a19cc8cf20a"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7600) },
                    { new Guid("f74d433e-d650-4d02-bfa4-3ea1970afe0f"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7530), new Guid("8f1ae030-1f68-402f-be1f-5b0296d98070"), new Guid("438fa0cd-85f3-4e53-9973-dac65030690e"), 0, null, new Guid("8c1830ed-d266-4063-b37d-030fe357755c"), new Guid("eddccb1a-50fa-4bf0-9c2d-e2a760a9113c"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7531) },
                    { new Guid("ce779e2c-0946-4623-9abf-e9ff9f30cdb1"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(4807), new Guid("e21fdd35-5933-4494-adbe-71d864828566"), new Guid("2044520f-1f88-464d-840e-af51ab9b0a22"), 0, null, new Guid("8c1830ed-d266-4063-b37d-030fe357755c"), new Guid("c4d41ef0-aebe-48d9-8bf1-62a4ef9b0674"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(4812) },
                    { new Guid("35d0626a-3ad4-476b-bb93-22d562cd2ed1"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7668), new Guid("4da3e0f7-ff4d-4697-80f2-a038d72d2b38"), new Guid("57bc14e2-3754-415a-922f-73f5adefd75a"), 2, null, new Guid("6d20cf15-db3d-46a7-af5b-2e3be6d66b82"), new Guid("82cbfeb4-6478-4235-b0d5-14aa107dbf0e"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7669) },
                    { new Guid("2aedc973-05ba-4012-be59-e2b2c564e093"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7462), new Guid("b9b4a14a-5952-4984-a1da-cb33c90314c5"), new Guid("2044520f-1f88-464d-840e-af51ab9b0a22"), 1, null, new Guid("0c44280a-5a46-4cb5-872c-a697be71e0f6"), new Guid("c4994594-f5e3-48b4-9a1c-40d149f62259"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7467) },
                    { new Guid("1dab7c28-c1d9-4c47-86a6-54993e48856f"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7776), new Guid("3ea9c671-9ed9-479c-ae10-4dd5a6fa44ae"), new Guid("57bc14e2-3754-415a-922f-73f5adefd75a"), 3, null, new Guid("0c44280a-5a46-4cb5-872c-a697be71e0f6"), new Guid("82cbfeb4-6478-4235-b0d5-14aa107dbf0e"), new DateTime(2021, 6, 2, 4, 0, 4, 871, DateTimeKind.Local).AddTicks(7778) }
                });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("634dc5e4-94f6-415d-887d-ae46042e3679"), 4, false, new Guid("9e663260-aee7-489c-8ca3-b5ac576d1520"), new Guid("996417e0-c5b4-4a56-9b80-82d53836eedc") },
                    { new Guid("f0e5c7fc-5eb7-4c43-bb0a-08fde8ba34d0"), 1, false, new Guid("dfdfadf1-24d4-42e5-a58e-1b09f31e47cc"), new Guid("0f6842a1-bb29-474f-a83e-9158687fdd55") },
                    { new Guid("2d03716d-e77b-44db-9438-d8187d90b1e2"), 2, false, new Guid("dfdfadf1-24d4-42e5-a58e-1b09f31e47cc"), new Guid("9a9fdf21-53e5-4c9f-910a-0162677cee0d") },
                    { new Guid("b9549e8e-d8be-4b7c-b282-eb084bfbc921"), 3, false, new Guid("dfdfadf1-24d4-42e5-a58e-1b09f31e47cc"), new Guid("fc35abaf-00c0-4272-8020-671365a6310f") },
                    { new Guid("32dca55c-ae6d-4358-bbc7-984dc9c900f7"), 4, false, new Guid("dfdfadf1-24d4-42e5-a58e-1b09f31e47cc"), new Guid("47471283-2f44-4713-bac8-2092749d1b5a") },
                    { new Guid("26c5905c-b313-4d6e-8f94-2a91ea4aaa7f"), 0, true, new Guid("3ff49be4-576a-492f-932e-8d106a9aed2b"), new Guid("44a5f6c8-1d84-40d0-ac6e-5a4bac966d0a") },
                    { new Guid("7bd52f99-248c-4eee-ac41-57c7fa6f6dd1"), 1, false, new Guid("3ff49be4-576a-492f-932e-8d106a9aed2b"), new Guid("5d7445b7-bfbb-4d76-851a-994ba93cdb7d") },
                    { new Guid("3b52c28e-8ff9-4f8d-9596-3d4db8c731c2"), 2, false, new Guid("3ff49be4-576a-492f-932e-8d106a9aed2b"), new Guid("71a20f8f-9c29-4b9b-b83d-63bf6e6f14dc") },
                    { new Guid("282f46bd-97ce-4fae-b134-73222a3bff2d"), 3, false, new Guid("3ff49be4-576a-492f-932e-8d106a9aed2b"), new Guid("63ef1b9e-f4b7-4d49-a563-9c94aaa65461") },
                    { new Guid("671b15d7-7f70-4c42-ad24-fa7d144e7747"), 4, false, new Guid("3ff49be4-576a-492f-932e-8d106a9aed2b"), new Guid("8d420653-ba07-4266-944f-2323cffea4b2") },
                    { new Guid("17670054-c693-457a-a7d3-696258f8c158"), 0, true, new Guid("118d4574-a027-4f8b-8466-41aac758b0d9"), new Guid("46777885-c09c-4cc8-b78a-f2dab121d85a") },
                    { new Guid("9bcb687f-d2a9-4450-9630-58bca553a47f"), 1, false, new Guid("118d4574-a027-4f8b-8466-41aac758b0d9"), new Guid("81679a7b-823a-4fc5-bea6-0c51c3945941") },
                    { new Guid("8c1634c6-5000-4436-aa53-4840574d73cc"), 2, false, new Guid("118d4574-a027-4f8b-8466-41aac758b0d9"), new Guid("48de392b-cbe3-4c4a-9501-d33a7c362d4b") },
                    { new Guid("f08ed24c-c3b9-41de-88ef-8e7a955efbf2"), 3, false, new Guid("118d4574-a027-4f8b-8466-41aac758b0d9"), new Guid("866c9c62-8863-476a-b88c-57341f2ff87f") },
                    { new Guid("faaecb54-7e83-43ba-9a60-e359adc2ec97"), 4, false, new Guid("118d4574-a027-4f8b-8466-41aac758b0d9"), new Guid("7356e067-b4a8-4cce-a33d-7c8b31697b2b") },
                    { new Guid("50e955d9-9a34-4cbf-9b69-13ab1d8653bd"), 0, true, new Guid("45595653-f4c8-4479-a0c6-e54d1e5dd5ec"), new Guid("5e7a2729-d079-47b2-88bf-28af1f4d46da") },
                    { new Guid("478b2ecc-f402-484a-8d1a-339a0239a316"), 1, false, new Guid("45595653-f4c8-4479-a0c6-e54d1e5dd5ec"), new Guid("e30e13dc-2a53-4d7e-bb1e-2c3d6ef647a7") },
                    { new Guid("23cb7955-24c7-483f-9ff6-21e941ab6528"), 2, false, new Guid("45595653-f4c8-4479-a0c6-e54d1e5dd5ec"), new Guid("763fefb7-defe-4df6-bf02-0ca3128b05be") },
                    { new Guid("8481af6f-7165-4af7-b43d-5bd840e22104"), 3, false, new Guid("45595653-f4c8-4479-a0c6-e54d1e5dd5ec"), new Guid("bf7d1904-f468-442c-816e-069c7bac6211") },
                    { new Guid("6a19999d-2bd6-472b-8aa9-f05487f029f4"), 4, false, new Guid("45595653-f4c8-4479-a0c6-e54d1e5dd5ec"), new Guid("d95cb5fe-2759-4bae-bca5-9558db27671e") },
                    { new Guid("7a2707a7-1198-43de-80f6-ff4d34970dd4"), 0, true, new Guid("35d0626a-3ad4-476b-bb93-22d562cd2ed1"), new Guid("09674527-54c1-4da9-8f84-d783f7ce3157") },
                    { new Guid("414e88fb-37a6-426b-8b76-8102489fd1cb"), 1, false, new Guid("35d0626a-3ad4-476b-bb93-22d562cd2ed1"), new Guid("8cd8aee0-d921-44dd-a5c7-9335b4ad99f8") },
                    { new Guid("5cae5093-e083-4bdc-bc2d-8abb9cda68c3"), 2, false, new Guid("35d0626a-3ad4-476b-bb93-22d562cd2ed1"), new Guid("e0832360-6da9-4b67-beb4-670bc59326ba") },
                    { new Guid("6359e5a9-2bc5-4d28-91e6-44e6a129cb9c"), 3, false, new Guid("35d0626a-3ad4-476b-bb93-22d562cd2ed1"), new Guid("f0507a87-4242-49c3-b93c-7785e5a04a55") },
                    { new Guid("1d8aa3ac-0379-4e65-8855-01de6fc96822"), 4, false, new Guid("35d0626a-3ad4-476b-bb93-22d562cd2ed1"), new Guid("a12e0bbd-c6e1-4fa4-9f51-96a87f2bc454") },
                    { new Guid("b2b95350-aa96-4905-9804-3e8573f400e6"), 0, true, new Guid("1dab7c28-c1d9-4c47-86a6-54993e48856f"), new Guid("ac7cd3b2-75a0-4f8b-8f60-c543ecd1ce7c") },
                    { new Guid("92edfca9-335d-436d-9a3f-a5ef6746878e"), 1, false, new Guid("1dab7c28-c1d9-4c47-86a6-54993e48856f"), new Guid("e0930762-2cf6-490f-b8f9-23feb5e5f09f") },
                    { new Guid("22669f42-6528-429f-9ffb-1497cf97111f"), 2, false, new Guid("1dab7c28-c1d9-4c47-86a6-54993e48856f"), new Guid("e9f5cec3-5f5a-4302-a714-fcec98ab7f91") },
                    { new Guid("62ecd8c2-2a0a-405c-999f-edc1376e16f3"), 0, true, new Guid("dfdfadf1-24d4-42e5-a58e-1b09f31e47cc"), new Guid("204925de-ddb2-441c-93af-78e17792bd7c") },
                    { new Guid("ef66be2b-be3a-4bcd-bc8c-32d42af1719e"), 3, false, new Guid("1dab7c28-c1d9-4c47-86a6-54993e48856f"), new Guid("66293c79-9cda-447d-845b-632d13f47c7c") },
                    { new Guid("36d8a9b1-b157-4359-99a8-a74924cf4341"), 4, false, new Guid("1dab7c28-c1d9-4c47-86a6-54993e48856f"), new Guid("ad13ce8d-70d2-4f47-ae68-83d7fffa4335") },
                    { new Guid("c8841f5b-7333-4fc0-9a5d-baf88c39ea4d"), 2, false, new Guid("9e663260-aee7-489c-8ca3-b5ac576d1520"), new Guid("c73a60bc-4ea5-43b2-9b13-406e9e3d447b") },
                    { new Guid("5c5a565b-9e5e-4fb6-b702-c9b8eabf1b49"), 0, true, new Guid("ce779e2c-0946-4623-9abf-e9ff9f30cdb1"), new Guid("186aa60f-cae8-4915-9d97-f3e4ae1ad268") },
                    { new Guid("e9659245-70e1-477b-8dc2-614dcd6c1951"), 1, false, new Guid("ce779e2c-0946-4623-9abf-e9ff9f30cdb1"), new Guid("9fbca7be-1808-49dc-ae42-bcc2c2617808") },
                    { new Guid("0cf82fe9-7ca2-47c5-989c-dfebe23d9ef8"), 2, false, new Guid("ce779e2c-0946-4623-9abf-e9ff9f30cdb1"), new Guid("7c59e70e-40f0-4de7-9ef1-c5231041de2b") },
                    { new Guid("3c6f64d0-3936-4ac4-968f-3e15f9b20167"), 3, false, new Guid("ce779e2c-0946-4623-9abf-e9ff9f30cdb1"), new Guid("69e868f6-aed1-4dd0-9d75-f33a03df4d91") },
                    { new Guid("a1c93a34-1c1f-487a-9eaa-58849e3eabae"), 4, false, new Guid("ce779e2c-0946-4623-9abf-e9ff9f30cdb1"), new Guid("b807c4c3-15c9-4a0c-a784-390b32932c3f") },
                    { new Guid("cf4d1a7b-1cfa-4fb7-8b49-98ef7b7681c5"), 0, true, new Guid("f74d433e-d650-4d02-bfa4-3ea1970afe0f"), new Guid("80c0165e-29cf-446a-b03b-8220f36d6c7c") },
                    { new Guid("a24b5775-742e-4931-8a99-9c36a5505bff"), 1, false, new Guid("f74d433e-d650-4d02-bfa4-3ea1970afe0f"), new Guid("24548991-e563-4a1f-a4d2-a65e53f218e3") },
                    { new Guid("347cf567-3314-4bab-98f0-4f35a4e5a7a5"), 2, false, new Guid("f74d433e-d650-4d02-bfa4-3ea1970afe0f"), new Guid("a171f801-f1d6-4af7-877d-b712dcf77380") },
                    { new Guid("813e7561-d2d3-4f1f-a9ad-2d9acdc7f78c"), 3, false, new Guid("f74d433e-d650-4d02-bfa4-3ea1970afe0f"), new Guid("3397ce40-1855-4706-a602-9aa7bbb4d0c2") },
                    { new Guid("9c8733e4-735b-4b3c-84e5-00e386ac5fc4"), 4, false, new Guid("f74d433e-d650-4d02-bfa4-3ea1970afe0f"), new Guid("baf772a2-c599-4a65-9f0a-35b3223d89fe") },
                    { new Guid("41272f91-4c1a-4431-b525-cb36657536fe"), 0, true, new Guid("bd1ad17e-fa41-4fff-8549-d316aa1f4419"), new Guid("f9522545-d7d5-4428-91e3-613a6e02acc0") },
                    { new Guid("f1e7259b-c486-4a34-8585-343c735a45dd"), 1, false, new Guid("bd1ad17e-fa41-4fff-8549-d316aa1f4419"), new Guid("ec856314-2737-43f3-bc75-0947cea6943f") },
                    { new Guid("16aaec3f-1e56-43db-86d5-0afb990b61c0"), 2, false, new Guid("bd1ad17e-fa41-4fff-8549-d316aa1f4419"), new Guid("438d4822-926e-4782-bfdf-9c78c6f1969c") },
                    { new Guid("361f6f97-f92f-4b36-8919-066cd0a2c42b"), 3, false, new Guid("bd1ad17e-fa41-4fff-8549-d316aa1f4419"), new Guid("c7ecc798-2df4-46db-ad87-984c475b3e57") },
                    { new Guid("3fb16208-acc0-46a8-8ce3-ea7a5bb7ddfe"), 4, false, new Guid("bd1ad17e-fa41-4fff-8549-d316aa1f4419"), new Guid("989ade4f-7d7a-4c98-8838-c65f83a6d8f0") },
                    { new Guid("112af349-e2d9-4caf-924a-007d2ac7bee0"), 0, true, new Guid("58275251-b6d9-4933-9ad8-b7124b0b457a"), new Guid("80db8ef3-dddf-42f8-ad17-0daacb5595bd") },
                    { new Guid("85346ef0-9d84-45c4-9ecf-48d7c4ca199e"), 1, false, new Guid("58275251-b6d9-4933-9ad8-b7124b0b457a"), new Guid("d5656b57-1138-4fb4-bfb0-b10c7f1c0a36") },
                    { new Guid("6115dcbc-ac71-441f-a79d-f0cefb388004"), 2, false, new Guid("58275251-b6d9-4933-9ad8-b7124b0b457a"), new Guid("0e717910-6574-4737-b539-470c09effe04") },
                    { new Guid("46b8f454-098a-4e85-a8b1-e2c1280e054b"), 3, false, new Guid("58275251-b6d9-4933-9ad8-b7124b0b457a"), new Guid("e6797bb4-d1f2-4e8e-ab25-7bdef9eda5e0") },
                    { new Guid("4bbe52a8-862e-47a4-8216-0bea4dc25a07"), 4, false, new Guid("58275251-b6d9-4933-9ad8-b7124b0b457a"), new Guid("d5c71fcc-7595-4eed-b023-1eef0d219b8b") },
                    { new Guid("0682ee81-7473-4ef1-9f74-425b7e27d188"), 0, true, new Guid("2aedc973-05ba-4012-be59-e2b2c564e093"), new Guid("eed7fd55-abe3-49ee-9079-d869d7096bc2") },
                    { new Guid("3d7df103-4924-49a5-b814-f4bfce6e0a8c"), 1, false, new Guid("2aedc973-05ba-4012-be59-e2b2c564e093"), new Guid("1ca5e685-08a0-4e22-8573-a7271d7c2639") },
                    { new Guid("d063f48e-0674-40d4-8b9c-f8a0f8142f60"), 2, false, new Guid("2aedc973-05ba-4012-be59-e2b2c564e093"), new Guid("4e5d4da6-057b-4d40-8c98-931a94d25a7e") },
                    { new Guid("cd25166e-641f-4eef-9c1a-3920a6a7d9ec"), 3, false, new Guid("2aedc973-05ba-4012-be59-e2b2c564e093"), new Guid("9fcc0550-7bb5-4325-a5cc-5daa0659acf6") },
                    { new Guid("59f16a3f-5c5c-419e-8848-f59c143e45d2"), 4, false, new Guid("2aedc973-05ba-4012-be59-e2b2c564e093"), new Guid("6de18948-4d3c-4ac5-b546-8b542e35ea28") },
                    { new Guid("097693ad-65a7-4a9c-b38b-514763a460ca"), 0, true, new Guid("9e663260-aee7-489c-8ca3-b5ac576d1520"), new Guid("8f4098cc-37d4-4d02-962c-2b5056ba508d") },
                    { new Guid("4b2c5977-7923-4211-9f27-570b42837ad5"), 1, false, new Guid("9e663260-aee7-489c-8ca3-b5ac576d1520"), new Guid("04454e34-cb66-4aa3-ac39-b270011092bc") },
                    { new Guid("93935f05-ca32-4798-a7a3-b3f886846c87"), 3, false, new Guid("9e663260-aee7-489c-8ca3-b5ac576d1520"), new Guid("50ae137b-df3e-47d7-baac-11f0f7294244") }
                });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[] { new Guid("1c6344ac-9456-47ba-865d-0159773d65a5"), new Guid("473c0534-e605-4293-90e8-80c145df5f98"), new DateTime(2021, 6, 2, 4, 0, 4, 888, DateTimeKind.Local).AddTicks(7370), new Guid("e7dff455-1e0e-4468-a2d5-8c109b46895e"), null, new DateTime(2021, 6, 2, 4, 0, 4, 888, DateTimeKind.Local).AddTicks(7371), new Guid("a517dc0c-a7ba-493d-ae81-9d988333f9d5") });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[,]
                {
                    { new Guid("67c71e97-24a4-4760-b02f-897a7b8cc0a8"), new Guid("cf4d1a7b-1cfa-4fb7-8b49-98ef7b7681c5"), new DateTime(2021, 6, 2, 4, 0, 4, 888, DateTimeKind.Local).AddTicks(5894), new Guid("f74d433e-d650-4d02-bfa4-3ea1970afe0f"), null, new DateTime(2021, 6, 2, 4, 0, 4, 888, DateTimeKind.Local).AddTicks(5911), new Guid("a517dc0c-a7ba-493d-ae81-9d988333f9d5") },
                    { new Guid("d6fe1708-4a2b-424e-b800-d091944a60cd"), new Guid("112af349-e2d9-4caf-924a-007d2ac7bee0"), new DateTime(2021, 6, 2, 4, 0, 4, 888, DateTimeKind.Local).AddTicks(7363), new Guid("58275251-b6d9-4933-9ad8-b7124b0b457a"), null, new DateTime(2021, 6, 2, 4, 0, 4, 888, DateTimeKind.Local).AddTicks(7364), new Guid("a517dc0c-a7ba-493d-ae81-9d988333f9d5") },
                    { new Guid("5b4879c0-7074-4ec4-85ae-21bc31f912b2"), new Guid("62ecd8c2-2a0a-405c-999f-edc1376e16f3"), new DateTime(2021, 6, 2, 4, 0, 4, 888, DateTimeKind.Local).AddTicks(7350), new Guid("dfdfadf1-24d4-42e5-a58e-1b09f31e47cc"), null, new DateTime(2021, 6, 2, 4, 0, 4, 888, DateTimeKind.Local).AddTicks(7356), new Guid("a517dc0c-a7ba-493d-ae81-9d988333f9d5") },
                    { new Guid("c81fa0e4-ddf6-47f8-a9f1-2a8c02cd3d5e"), new Guid("26c5905c-b313-4d6e-8f94-2a91ea4aaa7f"), new DateTime(2021, 6, 2, 4, 0, 4, 888, DateTimeKind.Local).AddTicks(7366), new Guid("3ff49be4-576a-492f-932e-8d106a9aed2b"), null, new DateTime(2021, 6, 2, 4, 0, 4, 888, DateTimeKind.Local).AddTicks(7367), new Guid("a517dc0c-a7ba-493d-ae81-9d988333f9d5") }
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
                name: "ix_external_user_profile_user_id",
                table: "external_user_profile",
                column: "user_id",
                unique: true);

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
                name: "ix_question_supporting_text_id",
                table: "question",
                column: "supporting_text_id");

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
                name: "ix_supporting_text_content_id",
                table: "supporting_text",
                column: "content_id",
                unique: true);

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
                name: "external_user_profile");

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
                name: "subject");

            migrationBuilder.DropTable(
                name: "supporting_text");

            migrationBuilder.DropTable(
                name: "incremented_text");
        }
    }
}
