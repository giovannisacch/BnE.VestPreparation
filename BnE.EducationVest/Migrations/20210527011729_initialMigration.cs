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
                columns: new[] { "id", "created_date", "exam_number", "exam_type", "removed_date", "updated_date" },
                values: new object[,]
                {
                    { new Guid("f14dc030-ed3f-444c-8229-afbdbc21e62d"), new DateTime(2021, 5, 26, 22, 17, 28, 462, DateTimeKind.Local).AddTicks(1084), 1, 2, null, new DateTime(2021, 5, 26, 22, 17, 28, 462, DateTimeKind.Local).AddTicks(1094) },
                    { new Guid("ad056657-0b69-4dfc-8506-b1934c90e717"), new DateTime(2021, 5, 26, 22, 17, 28, 462, DateTimeKind.Local).AddTicks(5267), 1, 1, null, new DateTime(2021, 5, 26, 22, 17, 28, 462, DateTimeKind.Local).AddTicks(5268) },
                    { new Guid("34f1894f-7b37-4bf9-852b-caa3c0fd2d92"), new DateTime(2021, 5, 26, 22, 17, 28, 462, DateTimeKind.Local).AddTicks(5286), 2, 1, null, new DateTime(2021, 5, 26, 22, 17, 28, 462, DateTimeKind.Local).AddTicks(5287) }
                });

            migrationBuilder.InsertData(
                table: "incremented_text",
                columns: new[] { "id", "content", "increments" },
                values: new object[,]
                {
                    { new Guid("c1dc2ced-e6c4-45b7-b35a-46c49a59fdcb"), "8,32", null },
                    { new Guid("2f668216-b342-4f0f-b2e1-132879ec44a0"), "4,64", null },
                    { new Guid("9ab9c2f7-9b49-47c3-9b7f-0fc13c25f835"), "maior que 131", null },
                    { new Guid("2cbd3059-6a8a-4482-a482-5c030dbaffd9"), "entre 130 e 131.", null },
                    { new Guid("61bd5ffe-a8e8-42b3-9d5d-63fad78820f9"), "entre 129 e 130.", null },
                    { new Guid("2cd274d0-74f6-4c08-8041-9dd936fd5f75"), "entre 128 e 129.", null },
                    { new Guid("ba24848d-bdd7-4938-95c1-8448518edcbe"), "menor do que 128.", null },
                    { new Guid("7ed0b9ef-d964-4335-8df8-864bc2759d5e"), "60°", null },
                    { new Guid("58101b81-eadc-4744-b27a-895e1c96b5b4"), "30°", null },
                    { new Guid("ff6e0d65-fb9d-459c-b5ae-a9c8551e9d83"), "45°", null },
                    { new Guid("0bb79463-a2ea-4ec5-b1ba-f2483de451d0"), "Testeee2", null },
                    { new Guid("76471e96-018c-49ef-87a2-c08a32bd1f4d"), "Teste", null },
                    { new Guid("474e41f5-a578-4a1d-bf57-4536e27ed07e"), "60°", null },
                    { new Guid("bbb3f13b-cdc1-4742-bc13-ad1dc6d2fe2b"), "30°", null },
                    { new Guid("0f954a62-dc32-401b-b433-0484ac0beb1d"), "45°", null },
                    { new Guid("b75b05b9-a490-493a-999c-1c6faac2d914"), "22,5°", null },
                    { new Guid("497b104d-42c5-4412-86ac-83d9379f4dfa"), "15°", null },
                    { new Guid("1152137b-d3da-4310-a198-c7a0eebef387"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("95e80451-e003-482c-9e7f-7f14a6977831"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("ac908c85-a982-4750-ab4c-a1dc2a97357d"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("d41eb73f-b49c-4b61-ad6f-58a7ae9e5432"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("19f7cf15-c556-4d15-b3eb-61561f5cbef7"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("c47ec339-5a14-4a5f-80df-c0ef750a15f5"), "6.62", null },
                    { new Guid("e882f699-ff92-4a16-8775-b4cbfa52e627"), "3,68", null },
                    { new Guid("82f8ef6b-f90c-4467-82dc-6e1d931074f2"), "5,34", null },
                    { new Guid("a13b8d4e-a4ab-4cea-8260-c3da510f39f7"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("59170b75-ba51-449a-b94a-51c46c9305b3"), "TEXTO DE APOIO SIMPLES SEM INCREMENTO", null },
                    { new Guid("9ddcd6f2-45b3-45d4-9c64-eeabcd513cba"), "TEXTO DE APOIO SIMPLES SEM INCREMENTO", null },
                    { new Guid("cf0bba4b-e611-42aa-ae2d-724acf93b779"), "TEXTO DE APOIO DE PORTUGUES COM IMAGEM \r\n {0}", "[{\"Index\":0,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("b7d256ab-f096-4205-af71-d648c0978373"), "TEXTO DE APOIO DE PORTUGUES COM IMAGEM \r\n {0}", "[{\"Index\":0,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("65f950d0-52b8-43f8-9209-44626e5f5e72"), "TEXTO DE APOIO DE PORTUGUES COM IMAGEM \r\n {0}", "[{\"Index\":0,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("06260f8e-0219-4085-a2bf-7ad64d1bc26b"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("165b32ea-bfb0-487c-9e87-87a1263bc48b"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("ee4980a4-db09-43ca-aa20-7d45f7ea1b56"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("1a8f3f78-cc83-4ab9-8ec0-0b34f3160d69"), "60°", null },
                    { new Guid("7e784afd-afc4-4567-8057-b49e07bcee9b"), "30°", null },
                    { new Guid("eb2864b0-6512-4188-b9b8-ed4ad58511c6"), "5,34", null },
                    { new Guid("a3d13dd8-67c8-41ce-860c-a64cab9c55fc"), "45°", null },
                    { new Guid("5ca7674e-5d4e-4ff8-aaeb-57610ee945f9"), "Teste", null },
                    { new Guid("0ff62f6e-f8e6-446c-bb43-dd36c25f53a8"), "60°", null },
                    { new Guid("81f8d6da-e6b1-4627-961b-f99b000300b3"), "30°", null },
                    { new Guid("5f1c1ab8-a11f-4868-bd5c-1258b2242d4d"), "45°", null },
                    { new Guid("e032c1d4-cf5c-46b3-849d-bad2cbca1735"), "22,5°", null },
                    { new Guid("5d4509ea-b7a4-4be0-b659-45a1de06af2a"), "15°", null },
                    { new Guid("63591237-c7ce-4ace-91c3-c3fe8301fd2d"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("28e1bbe5-b1e8-4c17-98ad-969b3a53786d"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("bb00dc76-82ca-4e45-9564-bc2363c4e50f"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("5a319788-910a-4138-9049-596621b6a99c"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("2b1e7762-6d1f-483d-954e-e610e10656b0"), "Testeee2", null },
                    { new Guid("f2575fdb-a1fa-49e4-98ee-9241de58dc9b"), "3,68", null },
                    { new Guid("ed01f8bd-f8c7-4850-bb13-9d34eae2fdf6"), "8,32", null },
                    { new Guid("66608218-3404-4421-b914-c6406ebb5cc4"), "TEXTO DE APOIO SIMPLES SEM INCREMENTO", null },
                    { new Guid("180b8e78-1cea-458b-977c-46fef40a0e31"), "4,64", null },
                    { new Guid("5fc71b33-2bf3-4403-9338-32d5b1e9ee98"), "maior que 131", null },
                    { new Guid("32a007a8-e19f-4003-a688-e23b224b0509"), "entre 130 e 131.", null },
                    { new Guid("a0236036-47d5-470f-89f8-b5386182c9d4"), "entre 129 e 130.", null },
                    { new Guid("60bd83c2-e8b8-4da6-a734-a17db772060b"), "entre 128 e 129.", null },
                    { new Guid("ffb8fb2c-7f2f-4166-b688-a34d6f732bcb"), "menor do que 128.", null },
                    { new Guid("a77035dc-8c11-4ba8-b679-6a22cb015bef"), "Enunciado teste com equacao {0} e imagem:  \r\n{1}\r\n  para teste", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("25acd6f3-e9fe-443f-a51f-c073e8f45030"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("14d1d61e-94f1-4c48-b744-d85024619e6d"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("c7e6a6df-5448-4d3a-9486-43052b320120"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("2538a89e-7e04-4113-906a-7d6f5e6fc8dd"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("aa9e6d66-0393-4bf2-91db-c84a33075746"), "Enunciado teste com equacao {0} e imagem:  \r\n{1}\r\n  para teste", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("ab41d61c-e51e-4d18-a82b-faaed5ca57f5"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("ccd2c9ef-6cb7-41bd-b1c3-2f408df371cd"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("7976f00c-8ae1-4bc2-a27b-e3300cbb37e2"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("5ac376b2-3ea6-4f66-8bf3-0242b4a4c68d"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("d2ada3e5-cc60-467a-ad44-12a008f8e98f"), "Enunciado teste com equacao {0} e imagem:  \r\n{1}\r\n  para teste", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("9c97efa5-d4d1-4a32-b047-c92aade57820"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("d82e85d5-c103-4b04-a94c-cb3c89b72394"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("dc2b0f8f-97b6-46fb-8860-8f5b5071a841"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("ec4dbd8e-4a01-4cbc-89bf-0d23ab57aeb4"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("af3fa51a-61cf-4593-8b66-e3405d3682fd"), "6.62", null },
                    { new Guid("4c1545ce-2f7c-4d40-9147-40d2b80094bf"), "6.62", null },
                    { new Guid("fa4f899e-41aa-43ef-8ffa-058e96eb8cb0"), "8,32", null },
                    { new Guid("146785c3-09dc-4765-af79-13877d818917"), "5,34", null },
                    { new Guid("27fb9dda-3a76-4929-9157-7ac676b6cdf4"), "4,64", null },
                    { new Guid("c549e7d9-1cb5-4094-a60d-391c51293f1c"), "maior que 131", null },
                    { new Guid("d8d8039e-0d0b-407b-a086-a8d275d722a2"), "entre 130 e 131.", null },
                    { new Guid("f5a0bd09-bb07-4acc-aaa2-ea25e09e9fd5"), "entre 129 e 130.", null },
                    { new Guid("e1a36e73-cfd6-4328-a95b-be9704445df7"), "entre 128 e 129.", null },
                    { new Guid("b75a6403-30e4-4899-90fd-cd88f0f63016"), "menor do que 128.", null },
                    { new Guid("c3c0f8ae-253d-48f6-9a14-49a2c7c7f280"), "60°", null },
                    { new Guid("d1d283de-0b7a-4efb-82d5-cec0e0daa902"), "30°", null },
                    { new Guid("01ae8eec-6148-449f-a762-56cf22f6fa0c"), "3,68", null },
                    { new Guid("811f5744-20d7-45a0-a40f-7323745e9850"), "Testeee2", null },
                    { new Guid("49d16231-dcde-49dd-91d4-1db4198288e4"), "45°", null },
                    { new Guid("723dd524-c1b3-4498-8134-85197b633f11"), "60°", null },
                    { new Guid("f960ba13-2e3b-447c-b228-eac84efdf258"), "30°", null },
                    { new Guid("3c0738d6-2f39-4453-bd4a-b1d6376ba904"), "45°", null },
                    { new Guid("6c743fbb-28b9-42cf-98d7-a8f033b0a5bb"), "22,5°", null },
                    { new Guid("a4b2e2c2-d683-48c5-a408-afe63df90297"), "15°", null },
                    { new Guid("5446cc25-e452-4b4e-adc9-bb59c22fd6e1"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("05579dc1-be89-4a73-adb6-52388ff6a9d1"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("413aa799-41ed-462e-b164-8ea8fd2ee994"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("70e30694-e467-4db5-8cdc-a0dcf5c78f96"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("02764c02-bb6d-497d-85d0-fc7cc3d3c846"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("51b97c82-69fd-409e-ba0f-604b2b85bdf0"), "Teste", null }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("ae285e78-42cd-4dd4-8519-aaf01676b81a"), new DateTime(2021, 5, 26, 22, 17, 28, 450, DateTimeKind.Local).AddTicks(6649), "Polinômios", null, null, new DateTime(2021, 5, 26, 22, 17, 28, 450, DateTimeKind.Local).AddTicks(6650) },
                    { new Guid("b8b0d476-3043-40ae-8191-9a9934021c6c"), new DateTime(2021, 5, 26, 22, 17, 28, 450, DateTimeKind.Local).AddTicks(6639), "Português", null, null, new DateTime(2021, 5, 26, 22, 17, 28, 450, DateTimeKind.Local).AddTicks(6644) },
                    { new Guid("196250c0-5317-4b10-926a-5b46e798325d"), new DateTime(2021, 5, 26, 22, 17, 28, 450, DateTimeKind.Local).AddTicks(5353), "Matemática", null, null, new DateTime(2021, 5, 26, 22, 17, 28, 450, DateTimeKind.Local).AddTicks(5827) }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "birth_date", "cognito_user_id", "created_date", "email", "gender", "is_teacher", "name", "phone_number", "removed_date", "updated_date", "address.cep", "address.city", "address.neighborhood", "address.number", "address.state", "address.street" },
                values: new object[] { new Guid("f99ffea3-cd4b-47f7-a1a7-58b5b8da821c"), new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e32ca6c-2a66-4ea6-a0c4-cf655dab5191"), new DateTime(2021, 5, 26, 22, 17, 28, 461, DateTimeKind.Local).AddTicks(1644), "sacchitiellogiovanni@gmail.com", "Masculino", false, "Giovanni Sacchitiello", "11991392711", null, new DateTime(2021, 5, 26, 22, 17, 28, 461, DateTimeKind.Local).AddTicks(1778), "03320020", "São Paulo", "Carrão", "148", "SP", "Rua antonio ciucio" });

            migrationBuilder.InsertData(
                table: "exam_period",
                columns: new[] { "id", "close_date", "exam_id", "open_date" },
                values: new object[,]
                {
                    { new Guid("e9f80347-899b-4620-9e51-e63318bd938e"), new DateTime(2021, 5, 30, 12, 0, 0, 0, DateTimeKind.Local), new Guid("f14dc030-ed3f-444c-8229-afbdbc21e62d"), new DateTime(2021, 5, 30, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("c3e8693b-e49b-4c0d-a0f0-6e2a6a071d50"), new DateTime(2021, 5, 31, 12, 0, 0, 0, DateTimeKind.Local), new Guid("f14dc030-ed3f-444c-8229-afbdbc21e62d"), new DateTime(2021, 5, 31, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("aa8e6018-462b-4fe6-b01d-ff96c992a4c9"), new DateTime(2021, 5, 27, 2, 17, 28, 462, DateTimeKind.Local).AddTicks(5211), new Guid("ad056657-0b69-4dfc-8506-b1934c90e717"), new DateTime(2021, 5, 26, 22, 17, 28, 462, DateTimeKind.Local).AddTicks(5211) },
                    { new Guid("60f9759e-3e17-4338-b89f-d089a4a91aa1"), new DateTime(2021, 5, 28, 0, 17, 28, 462, DateTimeKind.Local).AddTicks(5211), new Guid("ad056657-0b69-4dfc-8506-b1934c90e717"), new DateTime(2021, 5, 27, 22, 17, 28, 462, DateTimeKind.Local).AddTicks(5211) },
                    { new Guid("b0fffcb9-f27b-4355-a6e7-0275e788cb4d"), new DateTime(2021, 5, 25, 0, 17, 28, 462, DateTimeKind.Local).AddTicks(5271), new Guid("34f1894f-7b37-4bf9-852b-caa3c0fd2d92"), new DateTime(2021, 5, 24, 22, 17, 28, 462, DateTimeKind.Local).AddTicks(5271) },
                    { new Guid("94400427-6ddd-4ab1-ab9a-ed77a9ce7a73"), new DateTime(2021, 5, 26, 0, 17, 28, 462, DateTimeKind.Local).AddTicks(5271), new Guid("34f1894f-7b37-4bf9-852b-caa3c0fd2d92"), new DateTime(2021, 5, 25, 22, 17, 28, 462, DateTimeKind.Local).AddTicks(5271) }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "supporting_text_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("e97f3fc0-5625-4159-bda4-08537e3b3241"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3220), new Guid("aa9e6d66-0393-4bf2-91db-c84a33075746"), new Guid("ad056657-0b69-4dfc-8506-b1934c90e717"), 4, null, new Guid("ae285e78-42cd-4dd4-8519-aaf01676b81a"), null, new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3221) },
                    { new Guid("790a0c51-8cdf-4cb5-893a-881f340da347"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3340), new Guid("a77035dc-8c11-4ba8-b679-6a22cb015bef"), new Guid("34f1894f-7b37-4bf9-852b-caa3c0fd2d92"), 4, null, new Guid("ae285e78-42cd-4dd4-8519-aaf01676b81a"), null, new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3341) },
                    { new Guid("02e07278-fa4e-454b-b019-c78f739cd7b1"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3087), new Guid("d2ada3e5-cc60-467a-ad44-12a008f8e98f"), new Guid("f14dc030-ed3f-444c-8229-afbdbc21e62d"), 4, null, new Guid("ae285e78-42cd-4dd4-8519-aaf01676b81a"), null, new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3088) }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[] { new Guid("7ce19256-9171-44ec-99bf-993c6e31878e"), new DateTime(2021, 5, 26, 22, 17, 28, 450, DateTimeKind.Local).AddTicks(6647), "Porcentagem", null, new Guid("196250c0-5317-4b10-926a-5b46e798325d"), new DateTime(2021, 5, 26, 22, 17, 28, 450, DateTimeKind.Local).AddTicks(6647) });

            migrationBuilder.InsertData(
                table: "supporting_text",
                columns: new[] { "id", "content_id" },
                values: new object[,]
                {
                    { new Guid("56725aa3-b954-4769-9645-75a98b8ed22a"), new Guid("59170b75-ba51-449a-b94a-51c46c9305b3") },
                    { new Guid("804ec3a0-9944-458d-91d1-c0fadff04f60"), new Guid("ee4980a4-db09-43ca-aa20-7d45f7ea1b56") },
                    { new Guid("a9643a46-cff5-4e2f-b7c9-78b040a750c4"), new Guid("165b32ea-bfb0-487c-9e87-87a1263bc48b") },
                    { new Guid("25af4530-96e5-4a53-9908-6fb305c7fdc9"), new Guid("06260f8e-0219-4085-a2bf-7ad64d1bc26b") },
                    { new Guid("5c0b25a1-a370-41c3-8ed5-d00364dcd41a"), new Guid("65f950d0-52b8-43f8-9209-44626e5f5e72") },
                    { new Guid("055edaae-8e7e-44a5-90d4-bb6962ea31d6"), new Guid("b7d256ab-f096-4205-af71-d648c0978373") },
                    { new Guid("ec4060bb-13bf-42a7-9b39-baa8123501ca"), new Guid("cf0bba4b-e611-42aa-ae2d-724acf93b779") },
                    { new Guid("fe9f72fe-9a5e-4ab2-abd0-7a21fb262bea"), new Guid("9ddcd6f2-45b3-45d4-9c64-eeabcd513cba") },
                    { new Guid("12f60edd-3c8b-42fd-a7eb-751e6ed9f312"), new Guid("66608218-3404-4421-b914-c6406ebb5cc4") }
                });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("c73adc93-af8f-4da3-94d0-91b0765e9b93"), 0, true, new Guid("02e07278-fa4e-454b-b019-c78f739cd7b1"), new Guid("51b97c82-69fd-409e-ba0f-604b2b85bdf0") },
                    { new Guid("2e9dbac2-f0a2-4709-a036-7b577b2b6946"), 4, false, new Guid("790a0c51-8cdf-4cb5-893a-881f340da347"), new Guid("1a8f3f78-cc83-4ab9-8ec0-0b34f3160d69") },
                    { new Guid("b8814492-f7a9-4aeb-84a6-abd9521a1fdc"), 2, false, new Guid("790a0c51-8cdf-4cb5-893a-881f340da347"), new Guid("a3d13dd8-67c8-41ce-860c-a64cab9c55fc") },
                    { new Guid("3a025ac1-6220-45e8-b81d-5c177a021982"), 1, false, new Guid("790a0c51-8cdf-4cb5-893a-881f340da347"), new Guid("2b1e7762-6d1f-483d-954e-e610e10656b0") },
                    { new Guid("2f488a88-831d-4300-aa18-de17ae02487c"), 0, true, new Guid("790a0c51-8cdf-4cb5-893a-881f340da347"), new Guid("5ca7674e-5d4e-4ff8-aaeb-57610ee945f9") },
                    { new Guid("2cba8923-6cd7-4476-aa1d-f5ab14c8ff9d"), 4, false, new Guid("e97f3fc0-5625-4159-bda4-08537e3b3241"), new Guid("7ed0b9ef-d964-4335-8df8-864bc2759d5e") },
                    { new Guid("86ca75b7-c137-4e0c-a76d-5a5f95b788d4"), 3, false, new Guid("e97f3fc0-5625-4159-bda4-08537e3b3241"), new Guid("58101b81-eadc-4744-b27a-895e1c96b5b4") },
                    { new Guid("3ccc9c2d-7a31-4c1b-b12c-4ba01bbfe6e4"), 3, false, new Guid("790a0c51-8cdf-4cb5-893a-881f340da347"), new Guid("7e784afd-afc4-4567-8057-b49e07bcee9b") },
                    { new Guid("fa615102-81f6-4676-a959-5864b491ffc7"), 1, false, new Guid("e97f3fc0-5625-4159-bda4-08537e3b3241"), new Guid("0bb79463-a2ea-4ec5-b1ba-f2483de451d0") },
                    { new Guid("bfa78639-6fb0-44cc-ae23-ee196d5d51b2"), 0, true, new Guid("e97f3fc0-5625-4159-bda4-08537e3b3241"), new Guid("76471e96-018c-49ef-87a2-c08a32bd1f4d") },
                    { new Guid("b457ce7d-3622-4e25-823e-ff6d1892ec21"), 4, false, new Guid("02e07278-fa4e-454b-b019-c78f739cd7b1"), new Guid("c3c0f8ae-253d-48f6-9a14-49a2c7c7f280") },
                    { new Guid("a665f1ac-7491-4cfd-b941-8aa92819d40c"), 3, false, new Guid("02e07278-fa4e-454b-b019-c78f739cd7b1"), new Guid("d1d283de-0b7a-4efb-82d5-cec0e0daa902") },
                    { new Guid("6d3983a7-6437-43b8-8eab-1728dc7043f1"), 2, false, new Guid("02e07278-fa4e-454b-b019-c78f739cd7b1"), new Guid("49d16231-dcde-49dd-91d4-1db4198288e4") },
                    { new Guid("5d0af673-cafd-470e-a3db-fbf8d0c6a0ef"), 1, false, new Guid("02e07278-fa4e-454b-b019-c78f739cd7b1"), new Guid("811f5744-20d7-45a0-a40f-7323745e9850") },
                    { new Guid("f727b385-9edd-4e21-87aa-e92194a5bb1c"), 2, false, new Guid("e97f3fc0-5625-4159-bda4-08537e3b3241"), new Guid("ff6e0d65-fb9d-459c-b5ae-a9c8551e9d83") }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "supporting_text_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("f7201cd0-9b4d-441f-acc7-ca9998a29a3b"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3253), new Guid("c7e6a6df-5448-4d3a-9486-43052b320120"), new Guid("34f1894f-7b37-4bf9-852b-caa3c0fd2d92"), 1, null, new Guid("7ce19256-9171-44ec-99bf-993c6e31878e"), new Guid("12f60edd-3c8b-42fd-a7eb-751e6ed9f312"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3254) },
                    { new Guid("f1e9d9d8-1a37-40cb-b885-a35dac725eb7"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3236), new Guid("2538a89e-7e04-4113-906a-7d6f5e6fc8dd"), new Guid("34f1894f-7b37-4bf9-852b-caa3c0fd2d92"), 0, null, new Guid("196250c0-5317-4b10-926a-5b46e798325d"), new Guid("12f60edd-3c8b-42fd-a7eb-751e6ed9f312"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3237) },
                    { new Guid("f3b95a22-8993-4f96-a4d0-2bb5d60db7f1"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3204), new Guid("ab41d61c-e51e-4d18-a82b-faaed5ca57f5"), new Guid("ad056657-0b69-4dfc-8506-b1934c90e717"), 3, null, new Guid("7ce19256-9171-44ec-99bf-993c6e31878e"), new Guid("56725aa3-b954-4769-9645-75a98b8ed22a"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3205) },
                    { new Guid("8462eca4-593e-48f7-a902-fa1595c391f5"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3176), new Guid("7976f00c-8ae1-4bc2-a27b-e3300cbb37e2"), new Guid("ad056657-0b69-4dfc-8506-b1934c90e717"), 1, null, new Guid("7ce19256-9171-44ec-99bf-993c6e31878e"), new Guid("56725aa3-b954-4769-9645-75a98b8ed22a"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3177) },
                    { new Guid("0bfb4e96-8a20-49f8-a903-81f4a89b915d"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3072), new Guid("9c97efa5-d4d1-4a32-b047-c92aade57820"), new Guid("f14dc030-ed3f-444c-8229-afbdbc21e62d"), 3, null, new Guid("7ce19256-9171-44ec-99bf-993c6e31878e"), new Guid("fe9f72fe-9a5e-4ab2-abd0-7a21fb262bea"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3073) },
                    { new Guid("a1ee604e-74d3-4a4c-a7fa-fed3f407e928"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3055), new Guid("d82e85d5-c103-4b04-a94c-cb3c89b72394"), new Guid("f14dc030-ed3f-444c-8229-afbdbc21e62d"), 2, null, new Guid("b8b0d476-3043-40ae-8191-9a9934021c6c"), new Guid("5c0b25a1-a370-41c3-8ed5-d00364dcd41a"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3056) },
                    { new Guid("3ee1ec1c-dc77-406e-ba17-5a662a8523bd"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3190), new Guid("ccd2c9ef-6cb7-41bd-b1c3-2f408df371cd"), new Guid("ad056657-0b69-4dfc-8506-b1934c90e717"), 2, null, new Guid("b8b0d476-3043-40ae-8191-9a9934021c6c"), new Guid("055edaae-8e7e-44a5-90d4-bb6962ea31d6"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3192) },
                    { new Guid("4b9b02d0-e092-472a-b9fd-334e677cf2dd"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3102), new Guid("5ac376b2-3ea6-4f66-8bf3-0242b4a4c68d"), new Guid("ad056657-0b69-4dfc-8506-b1934c90e717"), 0, null, new Guid("196250c0-5317-4b10-926a-5b46e798325d"), new Guid("a9643a46-cff5-4e2f-b7c9-78b040a750c4"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3103) },
                    { new Guid("19960c76-0b10-4752-bf27-f84206493326"), new DateTime(2021, 5, 26, 22, 17, 28, 451, DateTimeKind.Local).AddTicks(9248), new Guid("ec4dbd8e-4a01-4cbc-89bf-0d23ab57aeb4"), new Guid("f14dc030-ed3f-444c-8229-afbdbc21e62d"), 0, null, new Guid("196250c0-5317-4b10-926a-5b46e798325d"), new Guid("804ec3a0-9944-458d-91d1-c0fadff04f60"), new DateTime(2021, 5, 26, 22, 17, 28, 451, DateTimeKind.Local).AddTicks(9274) },
                    { new Guid("8e38f046-a104-4a87-b810-d4d0c4440e69"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3304), new Guid("14d1d61e-94f1-4c48-b744-d85024619e6d"), new Guid("34f1894f-7b37-4bf9-852b-caa3c0fd2d92"), 2, null, new Guid("b8b0d476-3043-40ae-8191-9a9934021c6c"), new Guid("12f60edd-3c8b-42fd-a7eb-751e6ed9f312"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3305) },
                    { new Guid("c57e10de-7a50-40d5-9eb4-c28509cc724f"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3028), new Guid("dc2b0f8f-97b6-46fb-8860-8f5b5071a841"), new Guid("f14dc030-ed3f-444c-8229-afbdbc21e62d"), 1, null, new Guid("7ce19256-9171-44ec-99bf-993c6e31878e"), new Guid("fe9f72fe-9a5e-4ab2-abd0-7a21fb262bea"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3037) },
                    { new Guid("c2db404c-3faa-4634-b1fe-99273357f13c"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3323), new Guid("25acd6f3-e9fe-443f-a51f-c073e8f45030"), new Guid("34f1894f-7b37-4bf9-852b-caa3c0fd2d92"), 3, null, new Guid("7ce19256-9171-44ec-99bf-993c6e31878e"), new Guid("12f60edd-3c8b-42fd-a7eb-751e6ed9f312"), new DateTime(2021, 5, 26, 22, 17, 28, 452, DateTimeKind.Local).AddTicks(3324) }
                });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("aba12316-8759-4681-89b5-d6acc0a09731"), 4, false, new Guid("0bfb4e96-8a20-49f8-a903-81f4a89b915d"), new Guid("723dd524-c1b3-4498-8134-85197b633f11") },
                    { new Guid("c193abf7-81cf-4ef0-a841-a4388e507baf"), 1, false, new Guid("8462eca4-593e-48f7-a902-fa1595c391f5"), new Guid("ed01f8bd-f8c7-4850-bb13-9d34eae2fdf6") },
                    { new Guid("b9e4977b-3c53-4097-b350-679b0ff588bc"), 2, false, new Guid("8462eca4-593e-48f7-a902-fa1595c391f5"), new Guid("af3fa51a-61cf-4593-8b66-e3405d3682fd") },
                    { new Guid("3ec03540-1bfd-4a3e-806c-a0e76f10ce2e"), 3, false, new Guid("8462eca4-593e-48f7-a902-fa1595c391f5"), new Guid("f2575fdb-a1fa-49e4-98ee-9241de58dc9b") },
                    { new Guid("9754d076-7593-4983-825a-d8960ee293bb"), 4, false, new Guid("8462eca4-593e-48f7-a902-fa1595c391f5"), new Guid("eb2864b0-6512-4188-b9b8-ed4ad58511c6") },
                    { new Guid("ce1c547f-299d-48fc-ac52-94819c1f73c7"), 0, true, new Guid("f3b95a22-8993-4f96-a4d0-2bb5d60db7f1"), new Guid("497b104d-42c5-4412-86ac-83d9379f4dfa") },
                    { new Guid("4c077329-9380-41d3-8e3a-17196d926251"), 1, false, new Guid("f3b95a22-8993-4f96-a4d0-2bb5d60db7f1"), new Guid("b75b05b9-a490-493a-999c-1c6faac2d914") },
                    { new Guid("a5e433cb-a2bf-4388-b693-b04d9f96372b"), 2, false, new Guid("f3b95a22-8993-4f96-a4d0-2bb5d60db7f1"), new Guid("0f954a62-dc32-401b-b433-0484ac0beb1d") },
                    { new Guid("4e32c570-8694-4df0-9e1f-a162e2fcc714"), 3, false, new Guid("f3b95a22-8993-4f96-a4d0-2bb5d60db7f1"), new Guid("bbb3f13b-cdc1-4742-bc13-ad1dc6d2fe2b") },
                    { new Guid("22a16dba-8f83-4d87-933f-cb6435ce3047"), 4, false, new Guid("f3b95a22-8993-4f96-a4d0-2bb5d60db7f1"), new Guid("474e41f5-a578-4a1d-bf57-4536e27ed07e") },
                    { new Guid("9ec4fc40-526f-4648-b8be-0b2b3f9d27b5"), 0, true, new Guid("f1e9d9d8-1a37-40cb-b885-a35dac725eb7"), new Guid("ba24848d-bdd7-4938-95c1-8448518edcbe") },
                    { new Guid("785511c9-7e8a-4c88-8092-ce44d30468e2"), 1, false, new Guid("f1e9d9d8-1a37-40cb-b885-a35dac725eb7"), new Guid("2cd274d0-74f6-4c08-8041-9dd936fd5f75") },
                    { new Guid("704986ee-d27e-4870-a583-b6a252e45ac8"), 2, false, new Guid("f1e9d9d8-1a37-40cb-b885-a35dac725eb7"), new Guid("61bd5ffe-a8e8-42b3-9d5d-63fad78820f9") },
                    { new Guid("590c1936-0192-4ab3-9d5d-a7e174e4476b"), 3, false, new Guid("f1e9d9d8-1a37-40cb-b885-a35dac725eb7"), new Guid("2cbd3059-6a8a-4482-a482-5c030dbaffd9") },
                    { new Guid("adc6c34d-0876-491a-accd-a7b312c632e2"), 4, false, new Guid("f1e9d9d8-1a37-40cb-b885-a35dac725eb7"), new Guid("9ab9c2f7-9b49-47c3-9b7f-0fc13c25f835") },
                    { new Guid("36dab494-eda8-4432-be5d-1fa6732d688d"), 0, true, new Guid("f7201cd0-9b4d-441f-acc7-ca9998a29a3b"), new Guid("2f668216-b342-4f0f-b2e1-132879ec44a0") },
                    { new Guid("a829a01f-878c-46fb-bf00-ed9597220035"), 1, false, new Guid("f7201cd0-9b4d-441f-acc7-ca9998a29a3b"), new Guid("c1dc2ced-e6c4-45b7-b35a-46c49a59fdcb") },
                    { new Guid("36aa459d-d7c6-4a43-b7a5-6416e312ddb2"), 2, false, new Guid("f7201cd0-9b4d-441f-acc7-ca9998a29a3b"), new Guid("c47ec339-5a14-4a5f-80df-c0ef750a15f5") },
                    { new Guid("4b0fb1c1-1c3b-4c57-b4ce-25f0b0de21a8"), 3, false, new Guid("f7201cd0-9b4d-441f-acc7-ca9998a29a3b"), new Guid("e882f699-ff92-4a16-8775-b4cbfa52e627") },
                    { new Guid("84c0108e-bd03-4ceb-b462-780f8b83152e"), 4, false, new Guid("f7201cd0-9b4d-441f-acc7-ca9998a29a3b"), new Guid("82f8ef6b-f90c-4467-82dc-6e1d931074f2") },
                    { new Guid("66a3a9c1-5b38-4967-a33e-bcafb92c17d5"), 0, true, new Guid("8e38f046-a104-4a87-b810-d4d0c4440e69"), new Guid("a13b8d4e-a4ab-4cea-8260-c3da510f39f7") },
                    { new Guid("cf77f8f9-4164-4249-b176-718e66038f3c"), 1, false, new Guid("8e38f046-a104-4a87-b810-d4d0c4440e69"), new Guid("5a319788-910a-4138-9049-596621b6a99c") },
                    { new Guid("927631da-c442-420a-bcaf-79e4c549a2a0"), 2, false, new Guid("8e38f046-a104-4a87-b810-d4d0c4440e69"), new Guid("bb00dc76-82ca-4e45-9564-bc2363c4e50f") },
                    { new Guid("6ee505dc-2760-4c25-983b-c52e7d79e67f"), 3, false, new Guid("8e38f046-a104-4a87-b810-d4d0c4440e69"), new Guid("28e1bbe5-b1e8-4c17-98ad-969b3a53786d") },
                    { new Guid("873eb9fe-e346-4b7a-b517-72de938f71ac"), 4, false, new Guid("8e38f046-a104-4a87-b810-d4d0c4440e69"), new Guid("63591237-c7ce-4ace-91c3-c3fe8301fd2d") },
                    { new Guid("41e4582f-d72a-4e0c-8cf7-969b5ab43a29"), 0, true, new Guid("c2db404c-3faa-4634-b1fe-99273357f13c"), new Guid("5d4509ea-b7a4-4be0-b659-45a1de06af2a") },
                    { new Guid("6fdb78c8-e613-458f-b76b-69ac4f83c6e7"), 1, false, new Guid("c2db404c-3faa-4634-b1fe-99273357f13c"), new Guid("e032c1d4-cf5c-46b3-849d-bad2cbca1735") },
                    { new Guid("861f3e0b-4707-44ee-a41f-717061ea92f9"), 2, false, new Guid("c2db404c-3faa-4634-b1fe-99273357f13c"), new Guid("5f1c1ab8-a11f-4868-bd5c-1258b2242d4d") },
                    { new Guid("d28adaf9-a382-4eeb-a96a-10f210cfb5ce"), 0, true, new Guid("8462eca4-593e-48f7-a902-fa1595c391f5"), new Guid("27fb9dda-3a76-4929-9157-7ac676b6cdf4") },
                    { new Guid("f2f3398c-bf31-43c1-87ab-08db175a2ce8"), 3, false, new Guid("c2db404c-3faa-4634-b1fe-99273357f13c"), new Guid("81f8d6da-e6b1-4627-961b-f99b000300b3") },
                    { new Guid("ca9b5109-82b8-4f36-91ea-1cc8f990a533"), 4, false, new Guid("c2db404c-3faa-4634-b1fe-99273357f13c"), new Guid("0ff62f6e-f8e6-446c-bb43-dd36c25f53a8") },
                    { new Guid("6767ad4e-dfcd-44ae-bb7c-3a4a977dd9eb"), 2, false, new Guid("0bfb4e96-8a20-49f8-a903-81f4a89b915d"), new Guid("3c0738d6-2f39-4453-bd4a-b1d6376ba904") },
                    { new Guid("901ea57a-bdd0-4630-b3ab-0ce789402192"), 0, true, new Guid("19960c76-0b10-4752-bf27-f84206493326"), new Guid("ffb8fb2c-7f2f-4166-b688-a34d6f732bcb") },
                    { new Guid("f7d8fa1d-39ca-4363-9e1e-4826f4d40b5b"), 1, false, new Guid("19960c76-0b10-4752-bf27-f84206493326"), new Guid("60bd83c2-e8b8-4da6-a734-a17db772060b") },
                    { new Guid("5c88ef1c-1250-4e50-9c33-bdde2a6cf222"), 2, false, new Guid("19960c76-0b10-4752-bf27-f84206493326"), new Guid("a0236036-47d5-470f-89f8-b5386182c9d4") },
                    { new Guid("4a02b593-6b94-400f-8939-a6e2b9397c86"), 3, false, new Guid("19960c76-0b10-4752-bf27-f84206493326"), new Guid("32a007a8-e19f-4003-a688-e23b224b0509") },
                    { new Guid("4f9882e3-a073-4e72-9377-1a8b5f8a73ef"), 4, false, new Guid("19960c76-0b10-4752-bf27-f84206493326"), new Guid("5fc71b33-2bf3-4403-9338-32d5b1e9ee98") },
                    { new Guid("d6e77b8c-c4a9-4c9e-89b0-aeb39ad695e6"), 0, true, new Guid("4b9b02d0-e092-472a-b9fd-334e677cf2dd"), new Guid("b75a6403-30e4-4899-90fd-cd88f0f63016") },
                    { new Guid("1a5e5513-67fe-45c3-9e8f-ebf44b59fcf0"), 1, false, new Guid("4b9b02d0-e092-472a-b9fd-334e677cf2dd"), new Guid("e1a36e73-cfd6-4328-a95b-be9704445df7") },
                    { new Guid("bf54aead-df45-46de-bbf4-58a035aecd9d"), 2, false, new Guid("4b9b02d0-e092-472a-b9fd-334e677cf2dd"), new Guid("f5a0bd09-bb07-4acc-aaa2-ea25e09e9fd5") },
                    { new Guid("5e01739b-cd88-4373-9166-03e55504064d"), 3, false, new Guid("4b9b02d0-e092-472a-b9fd-334e677cf2dd"), new Guid("d8d8039e-0d0b-407b-a086-a8d275d722a2") },
                    { new Guid("b44c845a-c4af-4ac8-baa6-3520528baa75"), 4, false, new Guid("4b9b02d0-e092-472a-b9fd-334e677cf2dd"), new Guid("c549e7d9-1cb5-4094-a60d-391c51293f1c") },
                    { new Guid("7a8a22b4-dab9-4274-9218-317a5ccd8bce"), 0, true, new Guid("a1ee604e-74d3-4a4c-a7fa-fed3f407e928"), new Guid("02764c02-bb6d-497d-85d0-fc7cc3d3c846") },
                    { new Guid("0a53030d-3c6a-43f7-89b5-a1b6a7322464"), 1, false, new Guid("a1ee604e-74d3-4a4c-a7fa-fed3f407e928"), new Guid("70e30694-e467-4db5-8cdc-a0dcf5c78f96") },
                    { new Guid("3c41cd7b-22b1-4216-a5f0-c12e855a7a56"), 2, false, new Guid("a1ee604e-74d3-4a4c-a7fa-fed3f407e928"), new Guid("413aa799-41ed-462e-b164-8ea8fd2ee994") },
                    { new Guid("d5db16ae-c18f-4f2e-8d64-a6964b3215d5"), 3, false, new Guid("a1ee604e-74d3-4a4c-a7fa-fed3f407e928"), new Guid("05579dc1-be89-4a73-adb6-52388ff6a9d1") },
                    { new Guid("110f5d38-3691-4ff1-997d-1bc03257c145"), 4, false, new Guid("a1ee604e-74d3-4a4c-a7fa-fed3f407e928"), new Guid("5446cc25-e452-4b4e-adc9-bb59c22fd6e1") },
                    { new Guid("c3dbaf69-021a-4412-8a4f-4b63675d2bfe"), 0, true, new Guid("3ee1ec1c-dc77-406e-ba17-5a662a8523bd"), new Guid("19f7cf15-c556-4d15-b3eb-61561f5cbef7") },
                    { new Guid("55ed9d2a-34c7-4fc4-b1a7-c3f077da8868"), 1, false, new Guid("3ee1ec1c-dc77-406e-ba17-5a662a8523bd"), new Guid("d41eb73f-b49c-4b61-ad6f-58a7ae9e5432") },
                    { new Guid("9386d3f6-b325-4ed9-beeb-3f648fe90868"), 2, false, new Guid("3ee1ec1c-dc77-406e-ba17-5a662a8523bd"), new Guid("ac908c85-a982-4750-ab4c-a1dc2a97357d") },
                    { new Guid("b3a0a1f6-053b-4666-8767-8b65e42e6ffc"), 3, false, new Guid("3ee1ec1c-dc77-406e-ba17-5a662a8523bd"), new Guid("95e80451-e003-482c-9e7f-7f14a6977831") },
                    { new Guid("39c4b0b1-ea4d-426a-a570-5f281e0f4eaf"), 4, false, new Guid("3ee1ec1c-dc77-406e-ba17-5a662a8523bd"), new Guid("1152137b-d3da-4310-a198-c7a0eebef387") },
                    { new Guid("257f64fe-c95d-4910-bb86-cb2f6e0bc6d4"), 0, true, new Guid("c57e10de-7a50-40d5-9eb4-c28509cc724f"), new Guid("180b8e78-1cea-458b-977c-46fef40a0e31") },
                    { new Guid("801f9e90-e9e9-488f-952f-7edb00836e84"), 1, false, new Guid("c57e10de-7a50-40d5-9eb4-c28509cc724f"), new Guid("fa4f899e-41aa-43ef-8ffa-058e96eb8cb0") },
                    { new Guid("858015aa-2d9b-4f16-8aee-5badb8282f62"), 2, false, new Guid("c57e10de-7a50-40d5-9eb4-c28509cc724f"), new Guid("4c1545ce-2f7c-4d40-9147-40d2b80094bf") },
                    { new Guid("3f1b35ce-7216-474e-bc52-742d82a136f0"), 3, false, new Guid("c57e10de-7a50-40d5-9eb4-c28509cc724f"), new Guid("01ae8eec-6148-449f-a762-56cf22f6fa0c") },
                    { new Guid("bb763623-c7f1-4265-9eb5-0941ebd26181"), 4, false, new Guid("c57e10de-7a50-40d5-9eb4-c28509cc724f"), new Guid("146785c3-09dc-4765-af79-13877d818917") },
                    { new Guid("90870a95-aab1-489b-ac5d-16a82b9741eb"), 0, true, new Guid("0bfb4e96-8a20-49f8-a903-81f4a89b915d"), new Guid("a4b2e2c2-d683-48c5-a408-afe63df90297") },
                    { new Guid("b20a1131-4092-4d84-80a0-ab5a2f41a897"), 1, false, new Guid("0bfb4e96-8a20-49f8-a903-81f4a89b915d"), new Guid("6c743fbb-28b9-42cf-98d7-a8f033b0a5bb") },
                    { new Guid("fff72ae0-a18d-498d-b15f-18dbd878f3df"), 3, false, new Guid("0bfb4e96-8a20-49f8-a903-81f4a89b915d"), new Guid("f960ba13-2e3b-447c-b228-eac84efdf258") }
                });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[] { new Guid("9bf9ee0a-10b9-41df-ab1c-1c48c3c99c5b"), new Guid("bfa78639-6fb0-44cc-ae23-ee196d5d51b2"), new DateTime(2021, 5, 26, 22, 17, 28, 473, DateTimeKind.Local).AddTicks(2301), new Guid("e97f3fc0-5625-4159-bda4-08537e3b3241"), null, new DateTime(2021, 5, 26, 22, 17, 28, 473, DateTimeKind.Local).AddTicks(2302), new Guid("f99ffea3-cd4b-47f7-a1a7-58b5b8da821c") });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[,]
                {
                    { new Guid("5ae408ee-94e3-4234-bb55-4a22792e6633"), new Guid("d6e77b8c-c4a9-4c9e-89b0-aeb39ad695e6"), new DateTime(2021, 5, 26, 22, 17, 28, 473, DateTimeKind.Local).AddTicks(474), new Guid("4b9b02d0-e092-472a-b9fd-334e677cf2dd"), null, new DateTime(2021, 5, 26, 22, 17, 28, 473, DateTimeKind.Local).AddTicks(548), new Guid("f99ffea3-cd4b-47f7-a1a7-58b5b8da821c") },
                    { new Guid("885c83b2-524e-4cdc-9286-125be9313123"), new Guid("c3dbaf69-021a-4412-8a4f-4b63675d2bfe"), new DateTime(2021, 5, 26, 22, 17, 28, 473, DateTimeKind.Local).AddTicks(2273), new Guid("3ee1ec1c-dc77-406e-ba17-5a662a8523bd"), null, new DateTime(2021, 5, 26, 22, 17, 28, 473, DateTimeKind.Local).AddTicks(2274), new Guid("f99ffea3-cd4b-47f7-a1a7-58b5b8da821c") },
                    { new Guid("d96428fb-af9e-47be-bb03-c2767ddf487d"), new Guid("d28adaf9-a382-4eeb-a96a-10f210cfb5ce"), new DateTime(2021, 5, 26, 22, 17, 28, 473, DateTimeKind.Local).AddTicks(2228), new Guid("8462eca4-593e-48f7-a902-fa1595c391f5"), null, new DateTime(2021, 5, 26, 22, 17, 28, 473, DateTimeKind.Local).AddTicks(2258), new Guid("f99ffea3-cd4b-47f7-a1a7-58b5b8da821c") },
                    { new Guid("07eea904-eac3-4dd1-b60a-dc89347cf54d"), new Guid("ce1c547f-299d-48fc-ac52-94819c1f73c7"), new DateTime(2021, 5, 26, 22, 17, 28, 473, DateTimeKind.Local).AddTicks(2284), new Guid("f3b95a22-8993-4f96-a4d0-2bb5d60db7f1"), null, new DateTime(2021, 5, 26, 22, 17, 28, 473, DateTimeKind.Local).AddTicks(2285), new Guid("f99ffea3-cd4b-47f7-a1a7-58b5b8da821c") }
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
