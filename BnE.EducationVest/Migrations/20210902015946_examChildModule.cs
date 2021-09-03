using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BnE.EducationVest.API.Migrations
{
    public partial class examChildModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_exam_exam_child_exam_module_id",
                table: "exam");

            migrationBuilder.DropIndex(
                name: "ix_exam_child_exam_module_id",
                table: "exam");

            migrationBuilder.DropIndex(
                name: "ix_exam_father_exam_module_id",
                table: "exam");

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("033f8fe2-906c-41be-b261-2e872537885c"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("0645a8d4-083e-40f0-b43a-90f5a63e5559"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("0956be28-45f2-4748-a4b9-333a733b3c0c"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("09747ea5-8ad1-4c29-8073-2b0c073ba730"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("0aa5ffb8-c55a-48f2-af11-1ba6875bf70a"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("0bda1b5b-9cb3-4aa2-a472-f2ab196988e2"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("0c889389-92ea-42b1-954d-eba83d0fbc36"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("0dbc299f-d541-4973-8095-3bb235485c12"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("0f80a1af-1156-45a3-a1df-989685c1403f"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("1248908d-1b01-4757-b55b-08afab2efe95"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("24eddcf7-dfc4-40c1-ba44-36850632b1b4"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("24fd4a9c-1a9f-4b3f-a790-ddb1790190aa"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("2d368d3b-65f6-4dc1-9fbd-b35547b43633"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("2f309afb-68ac-403e-a18a-daea73960f40"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("30401158-612c-4a98-a011-f7ed5df85e2a"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("318b68e9-8b11-4165-9fc6-307e8fe387ed"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("3410ab0c-ff3a-48c0-9f37-011b2fe8a934"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("378494a1-d650-4d44-b24b-7f19eabff388"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("37c96d05-5c96-4244-b21f-97d559fcc5f4"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("3ab018e8-5d73-4464-b865-93034a521d39"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("3b432b20-3eb8-489e-80f9-f52ac62109a6"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("415530ea-ee2c-43d7-9527-819a7e727c66"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("415f01db-507b-44ab-854b-6b47895a0ce8"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("454d70cf-2862-40d0-93d3-87c28430b6c5"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("46441540-aa2c-40f4-9312-20ab49fffec7"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("49677620-112a-41fe-ab8c-191b5154b60f"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("4cd84e7c-8a34-4859-a706-cfa11c89902f"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("564e5d77-eeb4-4f33-a17b-602772b81cbc"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("5977ac25-fd2c-4a88-9b56-658af982ef41"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("605d5cd6-7483-45eb-a2da-165fd0f7bbc2"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("6322a5a0-90d4-4cd4-adca-e5e02fa20b7d"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("70bae2ac-d6b5-40a4-b2b1-07f3884c4c96"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("711e4d66-aa38-446e-9069-adb4a9a903fb"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("76494bc6-e642-44ad-9f18-77ce61aab096"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("76698ba0-b8ba-4db7-aafc-2cab86071416"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("7671463d-a2e6-46d9-8a03-53064a9eb90b"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("797c74ab-4252-4396-98be-831d5e27c661"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("7ab68517-19b8-4d5b-8411-c62372be3bd0"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("7b20e11c-f204-43f9-b4c9-9ee083c4411e"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("7e4921a1-380b-44ac-a703-f0017607c7e7"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("7fb87752-aef1-4c2b-8409-3d83b574f7e5"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("82b74127-5353-4ee6-bb54-21b6b31918f8"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("89d42166-781d-4c6f-bf68-ccbde0ba43bf"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("8cb5db6a-0442-4155-9d1b-e5e95176ceb1"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("913e1c1e-858e-415f-9335-e7f7d868dfb6"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("9c193b1f-2f40-46d9-b19c-71d368dc1fdd"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("9ccfbf94-5cd5-43b5-9eae-0e5194cbf920"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("a0359eb9-6a7a-43b2-bff4-baf38a21fdb4"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("a7a6f9df-47d5-455a-8656-2ac6ab478183"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("a967d9f0-00af-4e29-9590-3e88e6814b22"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("a9a2b0b5-a1ba-4a22-a44d-fd61100d7247"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("ac1e7795-1c0e-4a4e-96b0-d5031f120aa1"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("af8df48a-ffea-4f26-bf9b-cdd6c33844d6"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("b2b1c61a-db61-4a88-8577-2902d42d3ec4"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("b44adc57-485b-443d-9f5a-b97bad5f5580"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("b6845666-db8a-411c-957b-418578fbd9f0"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("bc7722aa-5340-4f67-9b34-311542b55214"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("bd9d380c-fcc1-43b8-ad84-13c132f3760c"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("bfe3a305-0bbf-4997-9483-385fcf1e400f"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("c0f1974c-f444-47dd-a7f4-c8c8c91e4a51"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("c71b7028-63f1-4034-b2a0-5fbef1ace034"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("caf47ca8-0d13-4d12-ba24-13d57d5ed2bd"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("d0d6638d-95e0-451c-a96b-5f47a17302bf"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("d5ed1616-fcee-4797-89da-e9bdce289f63"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("d85ab6fb-70f0-4974-b506-402fcb1a10a5"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("dacc8008-9930-4261-a460-2f0c2e4a182c"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("e12da43e-87ac-49e7-9de9-a3bdd610ab50"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("e2a4d9b6-e649-4e33-ae65-47122c9fccf8"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("e57c2fe8-e2d7-4b08-8a0a-af3913191506"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("fdc74669-41d8-4cbb-a974-5b760965b37b"));

            migrationBuilder.DeleteData(
                table: "exam_period",
                keyColumn: "id",
                keyValue: new Guid("16206306-a4bc-47bd-a1a2-925a528d1728"));

            migrationBuilder.DeleteData(
                table: "exam_period",
                keyColumn: "id",
                keyValue: new Guid("7207a822-1c99-47ee-86c5-ea618d2a844d"));

            migrationBuilder.DeleteData(
                table: "exam_period",
                keyColumn: "id",
                keyValue: new Guid("98350749-7032-4bfa-9ba8-058966533544"));

            migrationBuilder.DeleteData(
                table: "exam_period",
                keyColumn: "id",
                keyValue: new Guid("9e2b3121-d2f5-4b1d-8c51-767e01202e4b"));

            migrationBuilder.DeleteData(
                table: "exam_period",
                keyColumn: "id",
                keyValue: new Guid("acd74f68-96bd-4478-973b-16b1ba36e59e"));

            migrationBuilder.DeleteData(
                table: "exam_period",
                keyColumn: "id",
                keyValue: new Guid("f25f3472-e199-48b6-8a10-f54a5334df70"));

            migrationBuilder.DeleteData(
                table: "question_answers",
                keyColumn: "id",
                keyValue: new Guid("38beff73-7120-4919-98b8-c005d6e4d55a"));

            migrationBuilder.DeleteData(
                table: "question_answers",
                keyColumn: "id",
                keyValue: new Guid("4c54ec65-50ab-4034-990c-3264da070cd0"));

            migrationBuilder.DeleteData(
                table: "question_answers",
                keyColumn: "id",
                keyValue: new Guid("701e3613-4eb5-4fb0-8f7b-64981745eab8"));

            migrationBuilder.DeleteData(
                table: "question_answers",
                keyColumn: "id",
                keyValue: new Guid("a098cac3-6c68-4be9-8a94-76fe1ad31fc2"));

            migrationBuilder.DeleteData(
                table: "question_answers",
                keyColumn: "id",
                keyValue: new Guid("aa5eab55-643f-446a-92fb-074cd1e5a9c9"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("3c9b0829-487a-4401-8f51-22e7d8383b8c"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("b0a3dd57-7047-4668-83ea-88c1235ea1ae"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("2be94c11-3696-4756-87f1-defaa33b40a4"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("38f1adb5-2c77-4790-bdf1-d0167e3763cc"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("58f8db34-df67-42d5-ad17-9f9f744537b2"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("ac66f2fe-ffa9-4a58-8438-9513048ad321"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("afd076a9-1259-4e79-8f10-c5235e8abe28"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("0096f9d7-74ce-4aa7-8a2f-3d6a3f7dde1e"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("028b49ab-ff8d-4151-afec-38e1e659c584"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("037974ac-58e4-4a1c-80d9-686caefbf614"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("052395e0-195d-4fd6-90df-8bb80dd61959"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("10648921-532c-41ba-bee0-b4a0975e56bb"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("14f05f80-89ee-4331-b6b2-7a0f3c425855"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("191fc247-df3f-45cc-90dd-1a6b1ea37a14"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("20536bdf-8f81-477d-84c4-4b68e30964b4"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("2be9fe46-c453-45a7-96f2-fbf2ddb61f74"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("350d29a8-90de-4869-9e94-ed07c2083825"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("352a4af7-1ef8-464e-84ca-775e9a4d0039"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("36f66b67-b31f-4d98-8e82-8e246273fbb7"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("381b97c0-ef39-4b9f-a83e-1864f8326f6a"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("4009b1d1-9765-4a94-a50c-6269a0adeef3"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("418f331a-5bf6-45b7-a39b-36363583402d"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("43ce1afb-92dd-4080-9c82-a123689c13cb"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("47fcae00-5bb9-4bc5-8594-db07833f88e4"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("49c623cb-29e5-4f7e-bf8d-962db0fa14bc"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("51a11976-7e6d-48c6-bd0a-54e3787d43bf"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("5fb2967f-bb49-4a75-9942-ab615f920d0c"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("614a5e35-aeb4-474c-9989-a81f76fc1259"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("6535c1f4-8edc-4676-89f5-091b23beeaf0"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("657151f5-2625-49ef-bfc5-8b505394952d"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("6b21c0cd-1db9-48b8-ad59-42f8adad9ac2"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("7106ba6c-f0cb-4510-b8cb-0419d41a27d5"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("7301483a-cafd-4197-ade4-1af383bae080"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("73adf393-0430-4c2c-a151-e1054d0b2a81"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("74f78f61-7fad-4755-82e2-8a368b275cc7"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("79334c4a-cee6-4328-8258-97b984520729"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("7d11008d-b0c2-4021-98d8-261518c6ff7b"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("80910323-ecae-414f-9417-12286ab923ea"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("812def4d-5a00-46e2-b0d4-8820676f65fd"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("82a599ac-c3c2-475f-9f9b-279546d7ccbf"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("85fb3f46-1200-4119-b0fb-4d305aee946b"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("8f4423d4-cc3a-43e0-b3fa-c2abb605aa30"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("91173c7c-aabb-4887-a567-3a666d0302a2"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("976ff0c9-5736-4957-b730-372ef45564bd"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("97dac685-3477-4875-a33b-6e8c349e9083"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("98a7148b-6bb5-4795-b067-a5740a15be24"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("993e21b7-50e0-4efe-b136-cc3885c46858"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("9b125ae2-e56c-45d8-8bfa-5699f70dd09c"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("9da93404-c7fa-4a5c-867b-7c63528cb31d"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("9e097f71-96ae-4325-acc1-5dc84ef2b18a"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("a0c1f048-f0b6-455e-a5ec-0a7fa8d7cab9"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("a43352af-c21b-43b3-8270-a354249a6948"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("ab349696-1ed8-4d9a-93ca-4428576142c8"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("b1675914-b577-42df-ac5d-c25ae5f37d69"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("b8031b9d-bda3-45fb-b4fa-108c116fecd4"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("b85e2a6c-5110-46a0-8512-0b7845deac73"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("bb05ca6a-f303-41ec-b4c8-b44536c23575"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c042d1dc-1cfb-49e7-8ee1-037f485f8920"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c346d4c7-9416-44f0-9b81-c802f2192d0d"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c3aa9184-f2b3-462e-bea3-26a7e9898682"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c4eb295a-290f-41af-a698-d693654ee8d4"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c5db1648-1e0c-48d5-bed1-c7e68256a627"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c6a59263-16f6-4e2a-9508-6b584d8075d9"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c79e3108-3c81-4de8-9578-baf91981f1f4"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("ce627606-b41f-4896-a311-6783f8c27340"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("cfd8f659-42b7-41ca-a329-3bfe5056dafc"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("d03b7c91-e4aa-48c6-8972-efd8cdf25476"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("d67d3f86-5461-4e06-9921-11d3a9d88072"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("d6abb460-4201-4d4f-8fe0-ecaed255f35c"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("dc095436-10a0-4994-b62a-2d40cce52921"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("e8edc645-e5f1-4aab-9ce9-36dac1e470de"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("e93702e1-d8a1-4783-9313-fb7dbd63d2aa"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("eee25dd0-14c4-43ba-8b50-ead27fe08b22"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("f2aee079-2fc8-4249-931a-8fa9eb56c0b6"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("f2e1c5ba-2fd7-438d-941a-4b306098b32d"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("f3baca77-d4ac-4f98-a186-28ac524182e3"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("f4b2b8fa-6317-4bb6-8810-4808a5fb1bc5"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("fecc3c4f-83bb-480e-8ce3-639d8cbaa600"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("ff17e4be-5b28-45dc-bcad-611c3fce7c74"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("2988c2f8-f0a3-4379-9f44-2473716560b5"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("3b54aad1-f948-4b51-8382-bde3050bee4b"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("51def46d-4554-4ea8-86f0-bf6878c1465e"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("55a650b4-aede-4e66-b74e-0765b1d55847"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("634ef7a8-451b-4e9c-9d4e-3fe453115e83"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("6c99e014-6aec-4c1a-ad56-af72af4b8870"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("ce66fa6d-8554-4f0e-8219-77de48985bfc"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("f255c080-acb5-4416-ab91-19344a69e7d9"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("f6b88984-2e9e-4b1d-9ca6-b1baa6ebf001"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("fee1b3fa-30f6-4f80-8b2a-1be58a055afd"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("2fd5f106-fc04-492a-b052-f5ab05feb480"));

            migrationBuilder.DeleteData(
                table: "exam",
                keyColumn: "id",
                keyValue: new Guid("0c39038e-2331-44b5-a4d6-c6ea8b31265c"));

            migrationBuilder.DeleteData(
                table: "exam",
                keyColumn: "id",
                keyValue: new Guid("292e0d58-73c2-4d0c-a38f-695c455a427e"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("109144c7-bf60-41a7-823c-5d49dbe50fd7"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("524a49aa-d2f3-45f8-be49-82e253466c67"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("5fc46a97-9abe-4a7c-afac-0a63de219c3b"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("65d0632e-a28b-4f3d-b648-1605da2eaf27"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("6ac67cd7-a320-466d-b215-36c9d808d9e2"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("7530c676-0ddb-4d46-9826-f4c99a78c244"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("7df1a7f6-a717-4ef0-8e14-2c9d51850419"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("b5c568ea-4fd7-465e-84a4-a78d582476f9"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("ca8a53d6-82da-489c-bd64-ca6730429681"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("d1e85694-d789-4bfb-9f00-7efd62a41125"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("e137ed45-89c6-43e8-9bf9-cffab21fcd72"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("e510394e-bdef-4b9e-9b2a-375ae3dfe19d"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("e9111dc3-3be6-4ade-b3c3-71cbc9e663ea"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("ebb3cc67-2bda-4d13-89e0-a7f57abf9cdd"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("ee1a5d29-920b-44bf-a986-baa5182651cb"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("655d9837-8c96-4637-aba1-3bd950b9538d"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("66755edb-dc2e-4204-99eb-abd34c0bbae0"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("ac8e2eda-a856-48d5-a824-61cc951d3e86"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("f3b19f35-b868-4993-b6af-c6b8c3eec55e"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("f4ee07b8-71a5-404d-b796-62b47eb83fa2"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("4e5bb375-1a43-4b89-b12c-161da8563c39"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("6cc46676-399a-44ad-90c9-cc445fc18242"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("73deb30c-8d71-4aba-b7ea-5a749f741b64"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("a7a1267b-e97c-43e6-aab7-b1dcdaf2b29b"));

            migrationBuilder.DeleteData(
                table: "exam",
                keyColumn: "id",
                keyValue: new Guid("3c883c88-efd7-4344-961c-89bc61d78839"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("09c0d02a-cf74-4d04-bed0-2a4051e4b53b"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("26b57fba-4c70-4cc7-8f5d-3a90399f27ee"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("5c0b58fd-c7b0-4330-81ea-2ab552549c4c"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("6d7f7788-04ec-474a-a54c-b121da11038a"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("76bcb2f0-060d-4513-a5b8-934098434412"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c4681e37-e3cb-4de5-888d-fa333782022d"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("eb386291-41c9-4f11-b3f0-3b0d0fd91a2f"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("fa14a1e1-4626-4c02-af13-e5b8d90118e2"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("fbb45eae-3d55-436f-976a-03d7d33774b0"));

            migrationBuilder.DeleteData(
                table: "subject",
                keyColumn: "id",
                keyValue: new Guid("0c38ec1e-ba98-4542-bcd0-8746b3c2b831"));

            migrationBuilder.DeleteData(
                table: "subject",
                keyColumn: "id",
                keyValue: new Guid("271fed33-f461-4445-aa6d-960cf69d69b5"));

            migrationBuilder.DeleteData(
                table: "subject",
                keyColumn: "id",
                keyValue: new Guid("bb7c03f7-5f68-4f09-a7af-821492ccfef4"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("745ff9b2-280f-43a1-bbfe-5dc2fbcc6d88"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("ae04d6b9-937a-4e2c-9913-6b22a29efe3d"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("ecc47b98-fc2b-4e2e-8bb7-71736303b1f0"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("793a0130-0195-4087-ba0c-4d5f4a6166dd"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("b426c1c5-b0c9-49b5-b28f-200fe814558f"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("dac1fa55-dbda-4ea0-ad0e-44c8a85f2976"));

            migrationBuilder.DeleteData(
                table: "subject",
                keyColumn: "id",
                keyValue: new Guid("255c114c-0542-45a1-8bd4-7da73f56075d"));

            migrationBuilder.DropColumn(
                name: "child_exam_module_id",
                table: "exam");

            migrationBuilder.InsertData(
                table: "exam",
                columns: new[] { "id", "created_date", "exam_model", "exam_number", "exam_topic", "exam_type", "father_exam_module_id", "removed_date", "updated_date" },
                values: new object[,]
                {
                    { new Guid("d83d3b2e-0d98-4401-963c-e89e336347ca"), new DateTime(2021, 9, 1, 22, 59, 45, 781, DateTimeKind.Local).AddTicks(3032), 0, 1, 3, 0, null, null, new DateTime(2021, 9, 1, 22, 59, 45, 781, DateTimeKind.Local).AddTicks(3052) },
                    { new Guid("b1d7ab79-d1ec-424b-9aff-e93e5d8f55c3"), new DateTime(2021, 9, 1, 22, 59, 45, 781, DateTimeKind.Local).AddTicks(5940), 1, 1, 3, 1, null, null, new DateTime(2021, 9, 1, 22, 59, 45, 781, DateTimeKind.Local).AddTicks(5941) },
                    { new Guid("332e41bb-32b2-42cd-949d-771a95e1bf3b"), new DateTime(2021, 9, 1, 22, 59, 45, 781, DateTimeKind.Local).AddTicks(5968), 1, 2, 3, 1, null, null, new DateTime(2021, 9, 1, 22, 59, 45, 781, DateTimeKind.Local).AddTicks(5969) }
                });

            migrationBuilder.InsertData(
                table: "incremented_text",
                columns: new[] { "id", "content", "increments" },
                values: new object[,]
                {
                    { new Guid("1f3defab-e184-4ace-9bdd-cd6ea0ecc15f"), "8,32", null },
                    { new Guid("9c19e47e-17de-401b-82ef-1d173b0cee49"), "4,64", null },
                    { new Guid("13919a65-4903-4030-a18f-18cde912ba50"), "maior que 131", null },
                    { new Guid("057936ec-dbab-490e-ade9-20dd420b91c7"), "entre 130 e 131.", null },
                    { new Guid("b31a2760-bb3b-4201-8996-1c70d11f5ec3"), "entre 129 e 130.", null },
                    { new Guid("ad4b553f-3942-4e6b-8309-bc0721387d4f"), "entre 128 e 129.", null },
                    { new Guid("7f0e0429-bc61-4273-86ba-9694a0a905db"), "menor do que 128.", null },
                    { new Guid("6fff1499-0a0f-44e3-bf8c-c2a9b5d344fa"), "60°", null },
                    { new Guid("15a29ea1-c908-4acb-a071-e74bff10c6f2"), "30°", null },
                    { new Guid("61612dca-c182-4bb9-8a94-9f5a77f73fe5"), "45°", null },
                    { new Guid("cb7df6d2-2d1a-4f80-9395-b85b9c474d23"), "Testeee2", null },
                    { new Guid("80a67e1d-5325-4260-9b3f-ee5ff8d826c4"), "Teste", null },
                    { new Guid("fb5aa51d-7cce-49e0-8011-85b928ca858f"), "60°", null },
                    { new Guid("16dfda6c-2592-4778-b51c-79246df22898"), "30°", null },
                    { new Guid("25f011ec-0cbe-4034-baf2-59645c6910f8"), "45°", null },
                    { new Guid("59fca079-c5d6-43d7-b9e8-408de49e4c4e"), "22,5°", null },
                    { new Guid("e98d3525-27d5-47c7-b207-e635865dfa35"), "15°", null },
                    { new Guid("3aa164b7-ae1d-41fc-9637-fa43b778c273"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("7bc93777-4747-4dd9-8df7-90ae03e81d02"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("ccdbd9f7-edc3-4079-a952-030bce89ac91"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("c427cbc7-9aa4-4fa3-a2ab-144682fb6675"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("ac696226-fe4f-485f-9787-eef28afbe818"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("48e549bb-0af6-4e13-8e59-d3992e76dd60"), "6.62", null },
                    { new Guid("3963f574-5471-49da-a58f-42a830bb1329"), "3,68", null },
                    { new Guid("1a270884-92cf-44f7-9fd2-729fbd894904"), "5,34", null },
                    { new Guid("0f3373fd-c112-4368-9ade-df5dd0ac5076"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("228d72d9-19a6-4746-8bc7-d2b519eda473"), "TEXTO DE APOIO SIMPLES SEM INCREMENTO", null },
                    { new Guid("23b37272-80a6-4c42-9146-1110c59b963d"), "TEXTO DE APOIO SIMPLES SEM INCREMENTO", null },
                    { new Guid("ed84f224-08a9-4351-b74c-1a0e89df6266"), "TEXTO DE APOIO DE PORTUGUES COM IMAGEM \r\n {0}", "[{\"Index\":0,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("53e3591f-537b-4256-aa9d-094c80884970"), "TEXTO DE APOIO DE PORTUGUES COM IMAGEM \r\n {0}", "[{\"Index\":0,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("0dfcd378-ff58-4db4-8b68-975ccd76739f"), "TEXTO DE APOIO DE PORTUGUES COM IMAGEM \r\n {0}", "[{\"Index\":0,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("d2e7c7d7-e8ca-40f5-9451-2aa6b130e012"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("de582164-1461-4bbe-98fe-7ad26bbc73fb"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("9cc1ecb8-c5db-4ef8-8905-46c2b8964b09"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("123f16a2-7767-4a32-873d-443283ee0c93"), "60°", null },
                    { new Guid("6195d006-d9f8-459e-afc3-9387d8f1ac94"), "30°", null },
                    { new Guid("3fd4552a-5345-41f5-8176-5f04526683f3"), "5,34", null },
                    { new Guid("a6b30dbe-df3e-4f69-af78-c4ae2e5810cb"), "45°", null },
                    { new Guid("c54effae-710f-4bd0-960d-615eb9693ec8"), "Teste", null },
                    { new Guid("2de1f17f-689a-4831-963e-9bb9518fe66e"), "60°", null },
                    { new Guid("6eaa2a7b-a020-45b0-976d-54a9df48c4e4"), "30°", null },
                    { new Guid("f0cd9589-0d2c-45cd-ba6d-fc30fefb24f6"), "45°", null },
                    { new Guid("f9574bd2-41eb-4e9b-87da-4e30a719e76b"), "22,5°", null },
                    { new Guid("d0bb6bf7-a451-4ee5-bfbc-d9c9ff705c00"), "15°", null },
                    { new Guid("eb5cee58-96b3-40a6-9730-23b033237dc1"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("95d956c5-5c53-4c20-87aa-6ee25476c0f7"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("888e6f5f-a6e0-4f96-96f3-d661227721c4"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("acdb1780-56c1-47b3-bb63-a04031b738a5"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("6ba893cd-8ad2-4235-9cbd-e11b42f81f30"), "Testeee2", null },
                    { new Guid("e77dfe02-29c4-4d66-92e2-7790b2469078"), "3,68", null },
                    { new Guid("171d0869-711d-4948-8479-725c800daef3"), "8,32", null },
                    { new Guid("306c3be7-abdf-4194-bfa3-b6f64208b353"), "TEXTO DE APOIO SIMPLES SEM INCREMENTO", null },
                    { new Guid("1bc19666-8b06-4859-b0b6-04d885f2967b"), "4,64", null },
                    { new Guid("0d49940a-76ef-43cb-b968-52a7295c2dfc"), "maior que 131", null },
                    { new Guid("a555ae7b-0496-45be-8f9a-ce507aaf4a03"), "entre 130 e 131.", null },
                    { new Guid("2d8aefe4-969f-4ebe-b4ea-924c436f54dd"), "entre 129 e 130.", null },
                    { new Guid("95ba52a3-9a19-449a-a555-cf589af2dde3"), "entre 128 e 129.", null },
                    { new Guid("c184b210-da5f-47e8-967a-d8fa638f0a31"), "menor do que 128.", null },
                    { new Guid("97d289c4-1666-4efc-b7bd-990841399657"), "Enunciado teste com equacao {0} e imagem:  \r\n{1}\r\n  para teste", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("c9aae1d6-1a53-4b29-9e1a-721c34d99825"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("c74fc043-5ed3-4f54-9541-f480404df0ca"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("a205fd1d-0d3c-4bd7-a52b-ef12cc1fa186"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("1876288b-0c0d-46df-8ff6-2ea5ba39b38b"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("98d26dd7-7fa3-4441-8a1d-2f3c327a2e34"), "Enunciado teste com equacao {0} e imagem:  \r\n{1}\r\n  para teste", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("6bdb60b5-c1cb-427e-96c1-902bc29dc2f3"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("aff16625-074b-4237-8994-2cde3e9f8fb6"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("01f09d44-f2db-44ae-9d41-83722ae12ca8"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("0edb1e54-ff68-4787-87da-5816d227d4cf"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("2f4912ef-4377-4c3d-8309-ec0729b2331d"), "Enunciado teste com equacao {0} e imagem:  \r\n{1}\r\n  para teste", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("554bf311-5862-4cd7-a410-3e3fd3185925"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("46e26cdc-d21b-46e1-83d3-afc9383bb73a"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("25fa20c6-cc6f-410b-a52b-7de660f71503"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("4ea7b7fd-c68c-4b51-8994-262435f6ce16"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("0e4b4db3-c836-40d8-aa75-53df9b4cb762"), "6.62", null },
                    { new Guid("1484bb10-6e0f-40d2-b4b9-cf793704621d"), "6.62", null },
                    { new Guid("c4a14691-9a53-4bd1-8e1f-92867361fef8"), "8,32", null },
                    { new Guid("3e6d5cde-3dc2-4f78-a928-fbda19fa405b"), "5,34", null },
                    { new Guid("42d3a1b3-31fe-4f77-a5e5-7beeff069b86"), "4,64", null },
                    { new Guid("59b95693-4c3e-41d9-a923-a760a259b2c8"), "maior que 131", null },
                    { new Guid("923ba28b-d64e-4290-8810-68ac4dfe8146"), "entre 130 e 131.", null },
                    { new Guid("d6c63920-fb34-4449-bf7b-51c744bfd8db"), "entre 129 e 130.", null },
                    { new Guid("f903f5e1-bd61-4bdf-8103-1a7a9fed552a"), "entre 128 e 129.", null },
                    { new Guid("d93cc0c2-50d2-4ad4-92ae-8f8f3d32b323"), "menor do que 128.", null },
                    { new Guid("6229c2f1-f154-49fb-b118-9141f7a3da77"), "60°", null },
                    { new Guid("f668724c-5708-4926-a48d-f9d4d5fb6574"), "30°", null },
                    { new Guid("c31b16a2-e698-417d-afe4-6db2a3293b7b"), "3,68", null },
                    { new Guid("2075d608-a1fb-4e71-9071-c6fd16ed7062"), "Testeee2", null },
                    { new Guid("ee96c35c-16a1-4d49-81ee-9c6da2d45c30"), "45°", null },
                    { new Guid("3216b39a-9d21-4fc2-8bf0-d79864086798"), "60°", null },
                    { new Guid("57e9a34a-8eae-46f6-9549-bad284af11f8"), "30°", null },
                    { new Guid("a7ed90d1-32ef-4028-b1d8-d6e437bcf1d3"), "45°", null },
                    { new Guid("22e47e64-4533-4066-9aaf-6107944abc2a"), "22,5°", null },
                    { new Guid("ae9ecc6d-e785-40f1-ae3c-a2ef31a2bf02"), "15°", null },
                    { new Guid("081f7280-c2bb-4767-9117-e69b91c8166b"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("25ec4987-68e2-4eca-8bb9-e47833cb9d33"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("4f2fade7-a47d-49de-bd0b-2355e09ec9f5"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("764b3c3c-d1f6-4f37-9e83-8c50cb1375b5"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("3a013888-6877-446e-8590-faa670db7f78"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("f39f9f83-7c3b-4072-b03b-731e7a5b2c41"), "Teste", null }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("5328674a-6706-439e-b2b1-a0a3e7f3d9fe"), new DateTime(2021, 9, 1, 22, 59, 45, 770, DateTimeKind.Local).AddTicks(8137), "Polinômios", null, null, new DateTime(2021, 9, 1, 22, 59, 45, 770, DateTimeKind.Local).AddTicks(8138) },
                    { new Guid("c61c07c1-2927-47bb-b37a-e22cd8d1a6de"), new DateTime(2021, 9, 1, 22, 59, 45, 770, DateTimeKind.Local).AddTicks(8128), "Português", null, null, new DateTime(2021, 9, 1, 22, 59, 45, 770, DateTimeKind.Local).AddTicks(8132) },
                    { new Guid("9c7835a3-3f71-4d06-990e-3149e87a7727"), new DateTime(2021, 9, 1, 22, 59, 45, 770, DateTimeKind.Local).AddTicks(7224), "Matemática", null, null, new DateTime(2021, 9, 1, 22, 59, 45, 770, DateTimeKind.Local).AddTicks(7557) }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "birth_date", "cognito_user_id", "created_date", "email", "gender", "name", "phone_number", "removed_date", "updated_date", "user_type", "was_accepted_terms", "address.cep", "address.city", "address.neighborhood", "address.state", "address.street" },
                values: new object[] { new Guid("c7fc1e61-a6cb-4b1e-8dbe-d2ba665da721"), new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e32ca6c-2a66-4ea6-a0c4-cf655dab5191"), new DateTime(2021, 9, 1, 22, 59, 45, 780, DateTimeKind.Local).AddTicks(2160), "sacchitiellogiovanni@gmail.com", "Masculino", "Giovanni Sacchitiello", "11991392711", null, new DateTime(2021, 9, 1, 22, 59, 45, 780, DateTimeKind.Local).AddTicks(2194), 0, false, "03320020", "São Paulo", "Carrão", "SP", "Rua antonio ciucio" });

            migrationBuilder.InsertData(
                table: "exam_period",
                columns: new[] { "id", "close_date", "exam_id", "open_date" },
                values: new object[,]
                {
                    { new Guid("7f867b11-31e9-4065-bed7-9a0300b100c6"), new DateTime(2021, 9, 5, 12, 0, 0, 0, DateTimeKind.Local), new Guid("d83d3b2e-0d98-4401-963c-e89e336347ca"), new DateTime(2021, 9, 5, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("72d89814-59d7-4c63-8405-16d9a3081bcb"), new DateTime(2021, 9, 6, 12, 0, 0, 0, DateTimeKind.Local), new Guid("d83d3b2e-0d98-4401-963c-e89e336347ca"), new DateTime(2021, 9, 6, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("76f426c1-3adb-49f5-b5c7-4426a564b484"), new DateTime(2021, 9, 2, 2, 59, 45, 781, DateTimeKind.Local).AddTicks(5904), new Guid("b1d7ab79-d1ec-424b-9aff-e93e5d8f55c3"), new DateTime(2021, 9, 1, 22, 59, 45, 781, DateTimeKind.Local).AddTicks(5904) },
                    { new Guid("a826720a-6283-462c-b6f4-fb5caea005fd"), new DateTime(2021, 9, 3, 0, 59, 45, 781, DateTimeKind.Local).AddTicks(5904), new Guid("b1d7ab79-d1ec-424b-9aff-e93e5d8f55c3"), new DateTime(2021, 9, 2, 22, 59, 45, 781, DateTimeKind.Local).AddTicks(5904) },
                    { new Guid("6af7c1f6-d46b-4ff1-bb68-968e4dd8cdd4"), new DateTime(2021, 8, 31, 0, 59, 45, 781, DateTimeKind.Local).AddTicks(5944), new Guid("332e41bb-32b2-42cd-949d-771a95e1bf3b"), new DateTime(2021, 8, 30, 22, 59, 45, 781, DateTimeKind.Local).AddTicks(5944) },
                    { new Guid("ef98e46f-1cf6-4965-8116-3c0af3118650"), new DateTime(2021, 9, 1, 0, 59, 45, 781, DateTimeKind.Local).AddTicks(5944), new Guid("332e41bb-32b2-42cd-949d-771a95e1bf3b"), new DateTime(2021, 8, 31, 22, 59, 45, 781, DateTimeKind.Local).AddTicks(5944) }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "supporting_text_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("92c609e1-70ef-4e87-9853-263f004c6bf5"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9306), new Guid("98d26dd7-7fa3-4441-8a1d-2f3c327a2e34"), new Guid("b1d7ab79-d1ec-424b-9aff-e93e5d8f55c3"), 4, null, new Guid("5328674a-6706-439e-b2b1-a0a3e7f3d9fe"), null, new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9307) },
                    { new Guid("b38da0e7-ac40-4a43-93eb-c0aa5a815616"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9412), new Guid("97d289c4-1666-4efc-b7bd-990841399657"), new Guid("332e41bb-32b2-42cd-949d-771a95e1bf3b"), 4, null, new Guid("5328674a-6706-439e-b2b1-a0a3e7f3d9fe"), null, new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9413) },
                    { new Guid("b628a8f1-525e-4b6c-9f34-4c4efd9e3834"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9199), new Guid("2f4912ef-4377-4c3d-8309-ec0729b2331d"), new Guid("d83d3b2e-0d98-4401-963c-e89e336347ca"), 4, null, new Guid("5328674a-6706-439e-b2b1-a0a3e7f3d9fe"), null, new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9200) }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[] { new Guid("5e194cb3-b0fd-4e56-aa03-e259a63d04fa"), new DateTime(2021, 9, 1, 22, 59, 45, 770, DateTimeKind.Local).AddTicks(8134), "Porcentagem", null, new Guid("9c7835a3-3f71-4d06-990e-3149e87a7727"), new DateTime(2021, 9, 1, 22, 59, 45, 770, DateTimeKind.Local).AddTicks(8135) });

            migrationBuilder.InsertData(
                table: "supporting_text",
                columns: new[] { "id", "content_id" },
                values: new object[,]
                {
                    { new Guid("1dc1ba88-4416-4757-8fb5-45aac05aa28c"), new Guid("228d72d9-19a6-4746-8bc7-d2b519eda473") },
                    { new Guid("fbb3e0c2-1688-41d8-9108-2478c7b5daa0"), new Guid("9cc1ecb8-c5db-4ef8-8905-46c2b8964b09") },
                    { new Guid("82e9e1db-aa45-47f3-a352-f335ce01e137"), new Guid("de582164-1461-4bbe-98fe-7ad26bbc73fb") },
                    { new Guid("739bead2-fa34-4582-a880-57083bdce932"), new Guid("d2e7c7d7-e8ca-40f5-9451-2aa6b130e012") },
                    { new Guid("6251c095-131c-41f9-aff9-7b341fe82a21"), new Guid("0dfcd378-ff58-4db4-8b68-975ccd76739f") },
                    { new Guid("0ecc3300-b64f-442a-9928-e59fccbe086a"), new Guid("53e3591f-537b-4256-aa9d-094c80884970") },
                    { new Guid("a2ac8762-7397-487a-b9ad-5a44260b3c25"), new Guid("ed84f224-08a9-4351-b74c-1a0e89df6266") },
                    { new Guid("67e0ce84-a2fd-4bf5-ac79-abfe1cdf923e"), new Guid("23b37272-80a6-4c42-9146-1110c59b963d") },
                    { new Guid("d1e5050d-29a8-4e6b-a590-06abd9635358"), new Guid("306c3be7-abdf-4194-bfa3-b6f64208b353") }
                });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("33991f47-3ed7-4a9b-bc98-8301d43ecfe8"), 0, true, new Guid("b628a8f1-525e-4b6c-9f34-4c4efd9e3834"), new Guid("f39f9f83-7c3b-4072-b03b-731e7a5b2c41") },
                    { new Guid("11dbf683-ec0b-4705-b9c2-4d4b84e3094c"), 4, false, new Guid("b38da0e7-ac40-4a43-93eb-c0aa5a815616"), new Guid("123f16a2-7767-4a32-873d-443283ee0c93") },
                    { new Guid("9bdb8a9a-576d-42d7-86f4-dc78961c0fdd"), 2, false, new Guid("b38da0e7-ac40-4a43-93eb-c0aa5a815616"), new Guid("a6b30dbe-df3e-4f69-af78-c4ae2e5810cb") },
                    { new Guid("3a00bdf4-ca3e-439a-93bb-1e789680f359"), 1, false, new Guid("b38da0e7-ac40-4a43-93eb-c0aa5a815616"), new Guid("6ba893cd-8ad2-4235-9cbd-e11b42f81f30") },
                    { new Guid("0be50231-55ec-4e49-ba54-ff383cf54958"), 0, true, new Guid("b38da0e7-ac40-4a43-93eb-c0aa5a815616"), new Guid("c54effae-710f-4bd0-960d-615eb9693ec8") },
                    { new Guid("a91c3366-f6bf-45bc-9676-522c92fbd246"), 4, false, new Guid("92c609e1-70ef-4e87-9853-263f004c6bf5"), new Guid("6fff1499-0a0f-44e3-bf8c-c2a9b5d344fa") },
                    { new Guid("dba3cccb-44c2-4ab8-97ce-665704389743"), 3, false, new Guid("92c609e1-70ef-4e87-9853-263f004c6bf5"), new Guid("15a29ea1-c908-4acb-a071-e74bff10c6f2") },
                    { new Guid("25e7d842-eb82-4c1f-a4e6-7755aa437ed6"), 3, false, new Guid("b38da0e7-ac40-4a43-93eb-c0aa5a815616"), new Guid("6195d006-d9f8-459e-afc3-9387d8f1ac94") },
                    { new Guid("28537ec6-85d6-49e2-9c8b-9007c69265d1"), 1, false, new Guid("92c609e1-70ef-4e87-9853-263f004c6bf5"), new Guid("cb7df6d2-2d1a-4f80-9395-b85b9c474d23") },
                    { new Guid("2ed5f67b-5e7d-4353-be83-fcd6469da654"), 0, true, new Guid("92c609e1-70ef-4e87-9853-263f004c6bf5"), new Guid("80a67e1d-5325-4260-9b3f-ee5ff8d826c4") },
                    { new Guid("deecdf66-3d78-4048-8538-8a7166bddcf2"), 4, false, new Guid("b628a8f1-525e-4b6c-9f34-4c4efd9e3834"), new Guid("6229c2f1-f154-49fb-b118-9141f7a3da77") },
                    { new Guid("7f5412a9-2eb6-40de-86da-24c2355650e9"), 3, false, new Guid("b628a8f1-525e-4b6c-9f34-4c4efd9e3834"), new Guid("f668724c-5708-4926-a48d-f9d4d5fb6574") },
                    { new Guid("dc58123d-ac30-44df-845a-c29c065ffbbb"), 2, false, new Guid("b628a8f1-525e-4b6c-9f34-4c4efd9e3834"), new Guid("ee96c35c-16a1-4d49-81ee-9c6da2d45c30") },
                    { new Guid("60d80ce0-a49e-48c3-8bbd-803375c231ad"), 1, false, new Guid("b628a8f1-525e-4b6c-9f34-4c4efd9e3834"), new Guid("2075d608-a1fb-4e71-9071-c6fd16ed7062") },
                    { new Guid("1021894c-ebbb-4202-a0eb-e2cccd01949b"), 2, false, new Guid("92c609e1-70ef-4e87-9853-263f004c6bf5"), new Guid("61612dca-c182-4bb9-8a94-9f5a77f73fe5") }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "supporting_text_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("910d0153-c665-40a4-90fd-7ea6fd2cde02"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9339), new Guid("a205fd1d-0d3c-4bd7-a52b-ef12cc1fa186"), new Guid("332e41bb-32b2-42cd-949d-771a95e1bf3b"), 1, null, new Guid("5e194cb3-b0fd-4e56-aa03-e259a63d04fa"), new Guid("d1e5050d-29a8-4e6b-a590-06abd9635358"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9340) },
                    { new Guid("a7783104-39de-40ef-8737-bc6e51f7c908"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9322), new Guid("1876288b-0c0d-46df-8ff6-2ea5ba39b38b"), new Guid("332e41bb-32b2-42cd-949d-771a95e1bf3b"), 0, null, new Guid("9c7835a3-3f71-4d06-990e-3149e87a7727"), new Guid("d1e5050d-29a8-4e6b-a590-06abd9635358"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9322) },
                    { new Guid("8f4372b0-e727-41e0-9fbf-06a728e0f029"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9292), new Guid("6bdb60b5-c1cb-427e-96c1-902bc29dc2f3"), new Guid("b1d7ab79-d1ec-424b-9aff-e93e5d8f55c3"), 3, null, new Guid("5e194cb3-b0fd-4e56-aa03-e259a63d04fa"), new Guid("1dc1ba88-4416-4757-8fb5-45aac05aa28c"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9293) },
                    { new Guid("3a619a5e-7b18-4786-9f0d-735838963e8a"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9233), new Guid("01f09d44-f2db-44ae-9d41-83722ae12ca8"), new Guid("b1d7ab79-d1ec-424b-9aff-e93e5d8f55c3"), 1, null, new Guid("5e194cb3-b0fd-4e56-aa03-e259a63d04fa"), new Guid("1dc1ba88-4416-4757-8fb5-45aac05aa28c"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9233) },
                    { new Guid("ef0eac0d-0ac9-41cc-92f1-8441b2084e93"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9185), new Guid("554bf311-5862-4cd7-a410-3e3fd3185925"), new Guid("d83d3b2e-0d98-4401-963c-e89e336347ca"), 3, null, new Guid("5e194cb3-b0fd-4e56-aa03-e259a63d04fa"), new Guid("67e0ce84-a2fd-4bf5-ac79-abfe1cdf923e"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9186) },
                    { new Guid("01359071-ba48-49ab-9c6f-d074cacd1da7"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9169), new Guid("46e26cdc-d21b-46e1-83d3-afc9383bb73a"), new Guid("d83d3b2e-0d98-4401-963c-e89e336347ca"), 2, null, new Guid("c61c07c1-2927-47bb-b37a-e22cd8d1a6de"), new Guid("6251c095-131c-41f9-aff9-7b341fe82a21"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9169) },
                    { new Guid("10dcca1d-53f1-4969-8f59-39ac9960c173"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9246), new Guid("aff16625-074b-4237-8994-2cde3e9f8fb6"), new Guid("b1d7ab79-d1ec-424b-9aff-e93e5d8f55c3"), 2, null, new Guid("c61c07c1-2927-47bb-b37a-e22cd8d1a6de"), new Guid("0ecc3300-b64f-442a-9928-e59fccbe086a"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9247) },
                    { new Guid("744b7ae2-58b0-4411-8be1-89d875500b55"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9217), new Guid("0edb1e54-ff68-4787-87da-5816d227d4cf"), new Guid("b1d7ab79-d1ec-424b-9aff-e93e5d8f55c3"), 0, null, new Guid("9c7835a3-3f71-4d06-990e-3149e87a7727"), new Guid("82e9e1db-aa45-47f3-a352-f335ce01e137"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9218) },
                    { new Guid("09af72e4-c5bf-479e-9e2a-de305084607d"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(6485), new Guid("4ea7b7fd-c68c-4b51-8994-262435f6ce16"), new Guid("d83d3b2e-0d98-4401-963c-e89e336347ca"), 0, null, new Guid("9c7835a3-3f71-4d06-990e-3149e87a7727"), new Guid("fbb3e0c2-1688-41d8-9108-2478c7b5daa0"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(6491) },
                    { new Guid("54087128-111d-425d-bc9f-6333e0521c0f"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9352), new Guid("c74fc043-5ed3-4f54-9541-f480404df0ca"), new Guid("332e41bb-32b2-42cd-949d-771a95e1bf3b"), 2, null, new Guid("c61c07c1-2927-47bb-b37a-e22cd8d1a6de"), new Guid("d1e5050d-29a8-4e6b-a590-06abd9635358"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9353) },
                    { new Guid("2d9e6050-8285-47f7-980d-c16cb35390fa"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9147), new Guid("25fa20c6-cc6f-410b-a52b-7de660f71503"), new Guid("d83d3b2e-0d98-4401-963c-e89e336347ca"), 1, null, new Guid("5e194cb3-b0fd-4e56-aa03-e259a63d04fa"), new Guid("67e0ce84-a2fd-4bf5-ac79-abfe1cdf923e"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9152) },
                    { new Guid("c4867bc1-042c-4bf9-bec8-ecfa433bba79"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9367), new Guid("c9aae1d6-1a53-4b29-9e1a-721c34d99825"), new Guid("332e41bb-32b2-42cd-949d-771a95e1bf3b"), 3, null, new Guid("5e194cb3-b0fd-4e56-aa03-e259a63d04fa"), new Guid("d1e5050d-29a8-4e6b-a590-06abd9635358"), new DateTime(2021, 9, 1, 22, 59, 45, 771, DateTimeKind.Local).AddTicks(9368) }
                });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("2c5bbe5f-f6ea-41fc-a904-73cdc349cbc2"), 4, false, new Guid("ef0eac0d-0ac9-41cc-92f1-8441b2084e93"), new Guid("3216b39a-9d21-4fc2-8bf0-d79864086798") },
                    { new Guid("4ed86d5c-2886-464e-b1b9-7c67d4bd6d9f"), 1, false, new Guid("3a619a5e-7b18-4786-9f0d-735838963e8a"), new Guid("171d0869-711d-4948-8479-725c800daef3") },
                    { new Guid("38063ee3-384e-4d8b-a726-7478dd775826"), 2, false, new Guid("3a619a5e-7b18-4786-9f0d-735838963e8a"), new Guid("0e4b4db3-c836-40d8-aa75-53df9b4cb762") },
                    { new Guid("70ff7a1c-3577-44aa-b1b4-be8f8f771173"), 3, false, new Guid("3a619a5e-7b18-4786-9f0d-735838963e8a"), new Guid("e77dfe02-29c4-4d66-92e2-7790b2469078") },
                    { new Guid("161cb166-47e4-40ab-9a6e-bf9635d36d62"), 4, false, new Guid("3a619a5e-7b18-4786-9f0d-735838963e8a"), new Guid("3fd4552a-5345-41f5-8176-5f04526683f3") },
                    { new Guid("dbba214e-4f3d-44f6-a519-0d1ec523c04c"), 0, true, new Guid("8f4372b0-e727-41e0-9fbf-06a728e0f029"), new Guid("e98d3525-27d5-47c7-b207-e635865dfa35") },
                    { new Guid("678f09d9-c3db-4ca4-a1b7-ee15d078e8d2"), 1, false, new Guid("8f4372b0-e727-41e0-9fbf-06a728e0f029"), new Guid("59fca079-c5d6-43d7-b9e8-408de49e4c4e") },
                    { new Guid("d515f4fd-dd8a-479b-a200-9a9ce49a2ca0"), 2, false, new Guid("8f4372b0-e727-41e0-9fbf-06a728e0f029"), new Guid("25f011ec-0cbe-4034-baf2-59645c6910f8") },
                    { new Guid("b6145d62-dad1-447b-89b3-8b6fd386692a"), 3, false, new Guid("8f4372b0-e727-41e0-9fbf-06a728e0f029"), new Guid("16dfda6c-2592-4778-b51c-79246df22898") },
                    { new Guid("f810c34b-4779-4614-bf1b-840630527b51"), 4, false, new Guid("8f4372b0-e727-41e0-9fbf-06a728e0f029"), new Guid("fb5aa51d-7cce-49e0-8011-85b928ca858f") },
                    { new Guid("e7a74bae-127e-46a3-b71a-04745360c657"), 0, true, new Guid("a7783104-39de-40ef-8737-bc6e51f7c908"), new Guid("7f0e0429-bc61-4273-86ba-9694a0a905db") },
                    { new Guid("63fdc34b-286d-4ea3-aad1-c30da49eddcd"), 1, false, new Guid("a7783104-39de-40ef-8737-bc6e51f7c908"), new Guid("ad4b553f-3942-4e6b-8309-bc0721387d4f") },
                    { new Guid("eda3390b-4cbf-44d8-9df7-7815b2978bd1"), 2, false, new Guid("a7783104-39de-40ef-8737-bc6e51f7c908"), new Guid("b31a2760-bb3b-4201-8996-1c70d11f5ec3") },
                    { new Guid("b0e4d08e-1942-4bc5-b562-d75e85dbe4dd"), 3, false, new Guid("a7783104-39de-40ef-8737-bc6e51f7c908"), new Guid("057936ec-dbab-490e-ade9-20dd420b91c7") },
                    { new Guid("11d7fc02-317b-42bc-a873-ce4da413b5e2"), 4, false, new Guid("a7783104-39de-40ef-8737-bc6e51f7c908"), new Guid("13919a65-4903-4030-a18f-18cde912ba50") },
                    { new Guid("0ab32ec9-85b9-4a4e-a445-f7a6571c9bd3"), 0, true, new Guid("910d0153-c665-40a4-90fd-7ea6fd2cde02"), new Guid("9c19e47e-17de-401b-82ef-1d173b0cee49") },
                    { new Guid("2e944256-0adf-478c-9484-e8437f1205fb"), 1, false, new Guid("910d0153-c665-40a4-90fd-7ea6fd2cde02"), new Guid("1f3defab-e184-4ace-9bdd-cd6ea0ecc15f") },
                    { new Guid("4099b104-1c46-41ee-b232-fd1e5778a8ab"), 2, false, new Guid("910d0153-c665-40a4-90fd-7ea6fd2cde02"), new Guid("48e549bb-0af6-4e13-8e59-d3992e76dd60") },
                    { new Guid("a043c354-192d-4eef-b3d2-d00e42e82368"), 3, false, new Guid("910d0153-c665-40a4-90fd-7ea6fd2cde02"), new Guid("3963f574-5471-49da-a58f-42a830bb1329") },
                    { new Guid("70aad871-3e57-4e6a-adda-ba9195645f0a"), 4, false, new Guid("910d0153-c665-40a4-90fd-7ea6fd2cde02"), new Guid("1a270884-92cf-44f7-9fd2-729fbd894904") },
                    { new Guid("5ac517e7-c1ea-4853-8242-f421cdb12375"), 0, true, new Guid("54087128-111d-425d-bc9f-6333e0521c0f"), new Guid("0f3373fd-c112-4368-9ade-df5dd0ac5076") },
                    { new Guid("b0285f75-7c0a-4088-9732-c826951c78be"), 1, false, new Guid("54087128-111d-425d-bc9f-6333e0521c0f"), new Guid("acdb1780-56c1-47b3-bb63-a04031b738a5") },
                    { new Guid("c698f719-2b44-4aad-8ef3-1b1bd7a0905b"), 2, false, new Guid("54087128-111d-425d-bc9f-6333e0521c0f"), new Guid("888e6f5f-a6e0-4f96-96f3-d661227721c4") },
                    { new Guid("a52d9f95-5638-4cbc-ab18-20b5ea503ecf"), 3, false, new Guid("54087128-111d-425d-bc9f-6333e0521c0f"), new Guid("95d956c5-5c53-4c20-87aa-6ee25476c0f7") },
                    { new Guid("3b22b603-4c8e-49c9-8067-668bc5c5fe89"), 4, false, new Guid("54087128-111d-425d-bc9f-6333e0521c0f"), new Guid("eb5cee58-96b3-40a6-9730-23b033237dc1") },
                    { new Guid("d9fe6902-15ac-4ad0-baed-bb71491d28a4"), 0, true, new Guid("c4867bc1-042c-4bf9-bec8-ecfa433bba79"), new Guid("d0bb6bf7-a451-4ee5-bfbc-d9c9ff705c00") },
                    { new Guid("6fc06d8a-9ead-4726-b216-85a732f94205"), 1, false, new Guid("c4867bc1-042c-4bf9-bec8-ecfa433bba79"), new Guid("f9574bd2-41eb-4e9b-87da-4e30a719e76b") },
                    { new Guid("d495ab60-13de-44b9-8789-9b3e9de2b222"), 2, false, new Guid("c4867bc1-042c-4bf9-bec8-ecfa433bba79"), new Guid("f0cd9589-0d2c-45cd-ba6d-fc30fefb24f6") },
                    { new Guid("f6c2ff2e-2084-41ff-850b-e34627db4fb9"), 0, true, new Guid("3a619a5e-7b18-4786-9f0d-735838963e8a"), new Guid("42d3a1b3-31fe-4f77-a5e5-7beeff069b86") },
                    { new Guid("d6c944bd-5220-44d7-9226-a2c932ee12e6"), 3, false, new Guid("c4867bc1-042c-4bf9-bec8-ecfa433bba79"), new Guid("6eaa2a7b-a020-45b0-976d-54a9df48c4e4") },
                    { new Guid("90c943d3-2392-414b-b788-ac08e3b90ce6"), 4, false, new Guid("c4867bc1-042c-4bf9-bec8-ecfa433bba79"), new Guid("2de1f17f-689a-4831-963e-9bb9518fe66e") },
                    { new Guid("22c0111d-8216-4341-8bed-fa633263d328"), 2, false, new Guid("ef0eac0d-0ac9-41cc-92f1-8441b2084e93"), new Guid("a7ed90d1-32ef-4028-b1d8-d6e437bcf1d3") },
                    { new Guid("3026227c-ff5f-41fa-8ffe-d9750ff597b2"), 0, true, new Guid("09af72e4-c5bf-479e-9e2a-de305084607d"), new Guid("c184b210-da5f-47e8-967a-d8fa638f0a31") },
                    { new Guid("821a65d1-dd0b-43f3-91e8-80fabd658bab"), 1, false, new Guid("09af72e4-c5bf-479e-9e2a-de305084607d"), new Guid("95ba52a3-9a19-449a-a555-cf589af2dde3") },
                    { new Guid("aa346f06-a26a-40d4-a4b9-b6cfc5b279f7"), 2, false, new Guid("09af72e4-c5bf-479e-9e2a-de305084607d"), new Guid("2d8aefe4-969f-4ebe-b4ea-924c436f54dd") },
                    { new Guid("d43c8ce4-afe8-400f-a846-1c9aee931b69"), 3, false, new Guid("09af72e4-c5bf-479e-9e2a-de305084607d"), new Guid("a555ae7b-0496-45be-8f9a-ce507aaf4a03") },
                    { new Guid("7eb1368e-af86-410c-8cf6-0e8b448c7b71"), 4, false, new Guid("09af72e4-c5bf-479e-9e2a-de305084607d"), new Guid("0d49940a-76ef-43cb-b968-52a7295c2dfc") },
                    { new Guid("3e3d69e5-c704-447a-83c3-65bd17c9ba8b"), 0, true, new Guid("744b7ae2-58b0-4411-8be1-89d875500b55"), new Guid("d93cc0c2-50d2-4ad4-92ae-8f8f3d32b323") },
                    { new Guid("442e5d51-e9af-4c97-9e63-acbc8245724e"), 1, false, new Guid("744b7ae2-58b0-4411-8be1-89d875500b55"), new Guid("f903f5e1-bd61-4bdf-8103-1a7a9fed552a") },
                    { new Guid("ca75f92b-83e7-4d8f-800b-69dffd2cbc18"), 2, false, new Guid("744b7ae2-58b0-4411-8be1-89d875500b55"), new Guid("d6c63920-fb34-4449-bf7b-51c744bfd8db") },
                    { new Guid("b2a2b8f1-095f-42e1-a598-1a6a17e6010f"), 3, false, new Guid("744b7ae2-58b0-4411-8be1-89d875500b55"), new Guid("923ba28b-d64e-4290-8810-68ac4dfe8146") },
                    { new Guid("75a68f44-52d2-4453-9f5e-11e1336a1789"), 4, false, new Guid("744b7ae2-58b0-4411-8be1-89d875500b55"), new Guid("59b95693-4c3e-41d9-a923-a760a259b2c8") },
                    { new Guid("9da6b4af-d3a6-45ac-af6b-0ae4ab5e6230"), 0, true, new Guid("01359071-ba48-49ab-9c6f-d074cacd1da7"), new Guid("3a013888-6877-446e-8590-faa670db7f78") },
                    { new Guid("0b90d194-a809-4220-8174-f50a69ddc9db"), 1, false, new Guid("01359071-ba48-49ab-9c6f-d074cacd1da7"), new Guid("764b3c3c-d1f6-4f37-9e83-8c50cb1375b5") },
                    { new Guid("a67a0224-80cc-4da9-88bf-bd11eb1fa914"), 2, false, new Guid("01359071-ba48-49ab-9c6f-d074cacd1da7"), new Guid("4f2fade7-a47d-49de-bd0b-2355e09ec9f5") },
                    { new Guid("bb94506d-135e-4889-9212-51310c0ae690"), 3, false, new Guid("01359071-ba48-49ab-9c6f-d074cacd1da7"), new Guid("25ec4987-68e2-4eca-8bb9-e47833cb9d33") },
                    { new Guid("b4a5ac9b-716b-4c10-a5de-a2fff8171121"), 4, false, new Guid("01359071-ba48-49ab-9c6f-d074cacd1da7"), new Guid("081f7280-c2bb-4767-9117-e69b91c8166b") },
                    { new Guid("55f25ffd-ada2-4143-8ed7-6b3ca616fb60"), 0, true, new Guid("10dcca1d-53f1-4969-8f59-39ac9960c173"), new Guid("ac696226-fe4f-485f-9787-eef28afbe818") },
                    { new Guid("f20b62a4-23fb-46c3-af24-4213a458f258"), 1, false, new Guid("10dcca1d-53f1-4969-8f59-39ac9960c173"), new Guid("c427cbc7-9aa4-4fa3-a2ab-144682fb6675") },
                    { new Guid("fbaada6a-d265-46a4-b6eb-64dd15c11c12"), 2, false, new Guid("10dcca1d-53f1-4969-8f59-39ac9960c173"), new Guid("ccdbd9f7-edc3-4079-a952-030bce89ac91") },
                    { new Guid("e2082264-b6de-4e7c-aa64-06a3d247ec79"), 3, false, new Guid("10dcca1d-53f1-4969-8f59-39ac9960c173"), new Guid("7bc93777-4747-4dd9-8df7-90ae03e81d02") },
                    { new Guid("266c6866-63f4-4221-aa40-061346c2ecc6"), 4, false, new Guid("10dcca1d-53f1-4969-8f59-39ac9960c173"), new Guid("3aa164b7-ae1d-41fc-9637-fa43b778c273") },
                    { new Guid("2670a226-4660-438f-9118-b5abd98ef37c"), 0, true, new Guid("2d9e6050-8285-47f7-980d-c16cb35390fa"), new Guid("1bc19666-8b06-4859-b0b6-04d885f2967b") },
                    { new Guid("105248bb-db13-4f91-b4cb-dca7dfad6b50"), 1, false, new Guid("2d9e6050-8285-47f7-980d-c16cb35390fa"), new Guid("c4a14691-9a53-4bd1-8e1f-92867361fef8") },
                    { new Guid("26569666-d090-455d-9439-91ae1be46d18"), 2, false, new Guid("2d9e6050-8285-47f7-980d-c16cb35390fa"), new Guid("1484bb10-6e0f-40d2-b4b9-cf793704621d") },
                    { new Guid("fc5ec6a9-e8ce-492d-9660-1b0d417827d7"), 3, false, new Guid("2d9e6050-8285-47f7-980d-c16cb35390fa"), new Guid("c31b16a2-e698-417d-afe4-6db2a3293b7b") },
                    { new Guid("cf8a1530-77cc-447d-99d2-b1f7b9881798"), 4, false, new Guid("2d9e6050-8285-47f7-980d-c16cb35390fa"), new Guid("3e6d5cde-3dc2-4f78-a928-fbda19fa405b") },
                    { new Guid("293e4ae3-f1cc-4087-bddc-14d9fb9cba0b"), 0, true, new Guid("ef0eac0d-0ac9-41cc-92f1-8441b2084e93"), new Guid("ae9ecc6d-e785-40f1-ae3c-a2ef31a2bf02") },
                    { new Guid("c5bd8a25-47da-4c84-8a86-9244eb915fc3"), 1, false, new Guid("ef0eac0d-0ac9-41cc-92f1-8441b2084e93"), new Guid("22e47e64-4533-4066-9aaf-6107944abc2a") },
                    { new Guid("980859aa-6dfe-4b17-8e12-59756268bfcd"), 3, false, new Guid("ef0eac0d-0ac9-41cc-92f1-8441b2084e93"), new Guid("57e9a34a-8eae-46f6-9549-bad284af11f8") }
                });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[] { new Guid("7b9df439-ac40-4b18-b05d-ae4bad4e1813"), new Guid("2ed5f67b-5e7d-4353-be83-fcd6469da654"), new DateTime(2021, 9, 1, 22, 59, 45, 788, DateTimeKind.Local).AddTicks(5736), new Guid("92c609e1-70ef-4e87-9853-263f004c6bf5"), null, new DateTime(2021, 9, 1, 22, 59, 45, 788, DateTimeKind.Local).AddTicks(5737), new Guid("c7fc1e61-a6cb-4b1e-8dbe-d2ba665da721") });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[,]
                {
                    { new Guid("d3a1e686-0006-4922-8c57-30213e4a87b4"), new Guid("3e3d69e5-c704-447a-83c3-65bd17c9ba8b"), new DateTime(2021, 9, 1, 22, 59, 45, 788, DateTimeKind.Local).AddTicks(4286), new Guid("744b7ae2-58b0-4411-8be1-89d875500b55"), null, new DateTime(2021, 9, 1, 22, 59, 45, 788, DateTimeKind.Local).AddTicks(4307), new Guid("c7fc1e61-a6cb-4b1e-8dbe-d2ba665da721") },
                    { new Guid("3d7bcbf6-86d4-4fd0-b0b5-9055234ffc97"), new Guid("55f25ffd-ada2-4143-8ed7-6b3ca616fb60"), new DateTime(2021, 9, 1, 22, 59, 45, 788, DateTimeKind.Local).AddTicks(5721), new Guid("10dcca1d-53f1-4969-8f59-39ac9960c173"), null, new DateTime(2021, 9, 1, 22, 59, 45, 788, DateTimeKind.Local).AddTicks(5722), new Guid("c7fc1e61-a6cb-4b1e-8dbe-d2ba665da721") },
                    { new Guid("43c03c72-1f92-413b-b0f5-4fab42e76621"), new Guid("f6c2ff2e-2084-41ff-850b-e34627db4fb9"), new DateTime(2021, 9, 1, 22, 59, 45, 788, DateTimeKind.Local).AddTicks(5708), new Guid("3a619a5e-7b18-4786-9f0d-735838963e8a"), null, new DateTime(2021, 9, 1, 22, 59, 45, 788, DateTimeKind.Local).AddTicks(5713), new Guid("c7fc1e61-a6cb-4b1e-8dbe-d2ba665da721") },
                    { new Guid("8047efb0-92fc-4342-b0d3-b62387016d36"), new Guid("dbba214e-4f3d-44f6-a519-0d1ec523c04c"), new DateTime(2021, 9, 1, 22, 59, 45, 788, DateTimeKind.Local).AddTicks(5729), new Guid("8f4372b0-e727-41e0-9fbf-06a728e0f029"), null, new DateTime(2021, 9, 1, 22, 59, 45, 788, DateTimeKind.Local).AddTicks(5730), new Guid("c7fc1e61-a6cb-4b1e-8dbe-d2ba665da721") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_exam_father_exam_module_id",
                table: "exam",
                column: "father_exam_module_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_exam_father_exam_module_id",
                table: "exam");

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("0ab32ec9-85b9-4a4e-a445-f7a6571c9bd3"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("0b90d194-a809-4220-8174-f50a69ddc9db"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("0be50231-55ec-4e49-ba54-ff383cf54958"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("1021894c-ebbb-4202-a0eb-e2cccd01949b"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("105248bb-db13-4f91-b4cb-dca7dfad6b50"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("11d7fc02-317b-42bc-a873-ce4da413b5e2"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("11dbf683-ec0b-4705-b9c2-4d4b84e3094c"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("161cb166-47e4-40ab-9a6e-bf9635d36d62"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("22c0111d-8216-4341-8bed-fa633263d328"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("25e7d842-eb82-4c1f-a4e6-7755aa437ed6"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("26569666-d090-455d-9439-91ae1be46d18"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("266c6866-63f4-4221-aa40-061346c2ecc6"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("2670a226-4660-438f-9118-b5abd98ef37c"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("28537ec6-85d6-49e2-9c8b-9007c69265d1"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("293e4ae3-f1cc-4087-bddc-14d9fb9cba0b"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("2c5bbe5f-f6ea-41fc-a904-73cdc349cbc2"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("2e944256-0adf-478c-9484-e8437f1205fb"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("3026227c-ff5f-41fa-8ffe-d9750ff597b2"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("33991f47-3ed7-4a9b-bc98-8301d43ecfe8"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("38063ee3-384e-4d8b-a726-7478dd775826"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("3a00bdf4-ca3e-439a-93bb-1e789680f359"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("3b22b603-4c8e-49c9-8067-668bc5c5fe89"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("4099b104-1c46-41ee-b232-fd1e5778a8ab"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("442e5d51-e9af-4c97-9e63-acbc8245724e"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("4ed86d5c-2886-464e-b1b9-7c67d4bd6d9f"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("5ac517e7-c1ea-4853-8242-f421cdb12375"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("60d80ce0-a49e-48c3-8bbd-803375c231ad"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("63fdc34b-286d-4ea3-aad1-c30da49eddcd"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("678f09d9-c3db-4ca4-a1b7-ee15d078e8d2"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("6fc06d8a-9ead-4726-b216-85a732f94205"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("70aad871-3e57-4e6a-adda-ba9195645f0a"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("70ff7a1c-3577-44aa-b1b4-be8f8f771173"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("75a68f44-52d2-4453-9f5e-11e1336a1789"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("7eb1368e-af86-410c-8cf6-0e8b448c7b71"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("7f5412a9-2eb6-40de-86da-24c2355650e9"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("821a65d1-dd0b-43f3-91e8-80fabd658bab"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("90c943d3-2392-414b-b788-ac08e3b90ce6"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("980859aa-6dfe-4b17-8e12-59756268bfcd"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("9bdb8a9a-576d-42d7-86f4-dc78961c0fdd"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("9da6b4af-d3a6-45ac-af6b-0ae4ab5e6230"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("a043c354-192d-4eef-b3d2-d00e42e82368"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("a52d9f95-5638-4cbc-ab18-20b5ea503ecf"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("a67a0224-80cc-4da9-88bf-bd11eb1fa914"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("a91c3366-f6bf-45bc-9676-522c92fbd246"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("aa346f06-a26a-40d4-a4b9-b6cfc5b279f7"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("b0285f75-7c0a-4088-9732-c826951c78be"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("b0e4d08e-1942-4bc5-b562-d75e85dbe4dd"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("b2a2b8f1-095f-42e1-a598-1a6a17e6010f"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("b4a5ac9b-716b-4c10-a5de-a2fff8171121"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("b6145d62-dad1-447b-89b3-8b6fd386692a"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("bb94506d-135e-4889-9212-51310c0ae690"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("c5bd8a25-47da-4c84-8a86-9244eb915fc3"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("c698f719-2b44-4aad-8ef3-1b1bd7a0905b"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("ca75f92b-83e7-4d8f-800b-69dffd2cbc18"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("cf8a1530-77cc-447d-99d2-b1f7b9881798"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("d43c8ce4-afe8-400f-a846-1c9aee931b69"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("d495ab60-13de-44b9-8789-9b3e9de2b222"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("d515f4fd-dd8a-479b-a200-9a9ce49a2ca0"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("d6c944bd-5220-44d7-9226-a2c932ee12e6"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("d9fe6902-15ac-4ad0-baed-bb71491d28a4"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("dba3cccb-44c2-4ab8-97ce-665704389743"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("dc58123d-ac30-44df-845a-c29c065ffbbb"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("deecdf66-3d78-4048-8538-8a7166bddcf2"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("e2082264-b6de-4e7c-aa64-06a3d247ec79"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("e7a74bae-127e-46a3-b71a-04745360c657"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("eda3390b-4cbf-44d8-9df7-7815b2978bd1"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("f20b62a4-23fb-46c3-af24-4213a458f258"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("f810c34b-4779-4614-bf1b-840630527b51"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("fbaada6a-d265-46a4-b6eb-64dd15c11c12"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("fc5ec6a9-e8ce-492d-9660-1b0d417827d7"));

            migrationBuilder.DeleteData(
                table: "exam_period",
                keyColumn: "id",
                keyValue: new Guid("6af7c1f6-d46b-4ff1-bb68-968e4dd8cdd4"));

            migrationBuilder.DeleteData(
                table: "exam_period",
                keyColumn: "id",
                keyValue: new Guid("72d89814-59d7-4c63-8405-16d9a3081bcb"));

            migrationBuilder.DeleteData(
                table: "exam_period",
                keyColumn: "id",
                keyValue: new Guid("76f426c1-3adb-49f5-b5c7-4426a564b484"));

            migrationBuilder.DeleteData(
                table: "exam_period",
                keyColumn: "id",
                keyValue: new Guid("7f867b11-31e9-4065-bed7-9a0300b100c6"));

            migrationBuilder.DeleteData(
                table: "exam_period",
                keyColumn: "id",
                keyValue: new Guid("a826720a-6283-462c-b6f4-fb5caea005fd"));

            migrationBuilder.DeleteData(
                table: "exam_period",
                keyColumn: "id",
                keyValue: new Guid("ef98e46f-1cf6-4965-8116-3c0af3118650"));

            migrationBuilder.DeleteData(
                table: "question_answers",
                keyColumn: "id",
                keyValue: new Guid("3d7bcbf6-86d4-4fd0-b0b5-9055234ffc97"));

            migrationBuilder.DeleteData(
                table: "question_answers",
                keyColumn: "id",
                keyValue: new Guid("43c03c72-1f92-413b-b0f5-4fab42e76621"));

            migrationBuilder.DeleteData(
                table: "question_answers",
                keyColumn: "id",
                keyValue: new Guid("7b9df439-ac40-4b18-b05d-ae4bad4e1813"));

            migrationBuilder.DeleteData(
                table: "question_answers",
                keyColumn: "id",
                keyValue: new Guid("8047efb0-92fc-4342-b0d3-b62387016d36"));

            migrationBuilder.DeleteData(
                table: "question_answers",
                keyColumn: "id",
                keyValue: new Guid("d3a1e686-0006-4922-8c57-30213e4a87b4"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("739bead2-fa34-4582-a880-57083bdce932"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("a2ac8762-7397-487a-b9ad-5a44260b3c25"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("2ed5f67b-5e7d-4353-be83-fcd6469da654"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("3e3d69e5-c704-447a-83c3-65bd17c9ba8b"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("55f25ffd-ada2-4143-8ed7-6b3ca616fb60"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("dbba214e-4f3d-44f6-a519-0d1ec523c04c"));

            migrationBuilder.DeleteData(
                table: "alternative",
                keyColumn: "id",
                keyValue: new Guid("f6c2ff2e-2084-41ff-850b-e34627db4fb9"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("057936ec-dbab-490e-ade9-20dd420b91c7"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("081f7280-c2bb-4767-9117-e69b91c8166b"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("0d49940a-76ef-43cb-b968-52a7295c2dfc"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("0e4b4db3-c836-40d8-aa75-53df9b4cb762"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("0f3373fd-c112-4368-9ade-df5dd0ac5076"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("123f16a2-7767-4a32-873d-443283ee0c93"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("13919a65-4903-4030-a18f-18cde912ba50"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("1484bb10-6e0f-40d2-b4b9-cf793704621d"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("15a29ea1-c908-4acb-a071-e74bff10c6f2"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("16dfda6c-2592-4778-b51c-79246df22898"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("171d0869-711d-4948-8479-725c800daef3"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("1a270884-92cf-44f7-9fd2-729fbd894904"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("1bc19666-8b06-4859-b0b6-04d885f2967b"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("1f3defab-e184-4ace-9bdd-cd6ea0ecc15f"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("2075d608-a1fb-4e71-9071-c6fd16ed7062"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("22e47e64-4533-4066-9aaf-6107944abc2a"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("25ec4987-68e2-4eca-8bb9-e47833cb9d33"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("25f011ec-0cbe-4034-baf2-59645c6910f8"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("2d8aefe4-969f-4ebe-b4ea-924c436f54dd"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("2de1f17f-689a-4831-963e-9bb9518fe66e"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("3216b39a-9d21-4fc2-8bf0-d79864086798"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("3963f574-5471-49da-a58f-42a830bb1329"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("3a013888-6877-446e-8590-faa670db7f78"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("3aa164b7-ae1d-41fc-9637-fa43b778c273"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("3e6d5cde-3dc2-4f78-a928-fbda19fa405b"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("3fd4552a-5345-41f5-8176-5f04526683f3"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("48e549bb-0af6-4e13-8e59-d3992e76dd60"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("4f2fade7-a47d-49de-bd0b-2355e09ec9f5"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("57e9a34a-8eae-46f6-9549-bad284af11f8"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("59b95693-4c3e-41d9-a923-a760a259b2c8"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("59fca079-c5d6-43d7-b9e8-408de49e4c4e"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("61612dca-c182-4bb9-8a94-9f5a77f73fe5"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("6195d006-d9f8-459e-afc3-9387d8f1ac94"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("6229c2f1-f154-49fb-b118-9141f7a3da77"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("6ba893cd-8ad2-4235-9cbd-e11b42f81f30"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("6eaa2a7b-a020-45b0-976d-54a9df48c4e4"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("6fff1499-0a0f-44e3-bf8c-c2a9b5d344fa"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("764b3c3c-d1f6-4f37-9e83-8c50cb1375b5"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("7bc93777-4747-4dd9-8df7-90ae03e81d02"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("7f0e0429-bc61-4273-86ba-9694a0a905db"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("888e6f5f-a6e0-4f96-96f3-d661227721c4"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("923ba28b-d64e-4290-8810-68ac4dfe8146"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("95ba52a3-9a19-449a-a555-cf589af2dde3"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("95d956c5-5c53-4c20-87aa-6ee25476c0f7"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("9c19e47e-17de-401b-82ef-1d173b0cee49"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("a555ae7b-0496-45be-8f9a-ce507aaf4a03"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("a6b30dbe-df3e-4f69-af78-c4ae2e5810cb"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("a7ed90d1-32ef-4028-b1d8-d6e437bcf1d3"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("acdb1780-56c1-47b3-bb63-a04031b738a5"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("ad4b553f-3942-4e6b-8309-bc0721387d4f"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("ae9ecc6d-e785-40f1-ae3c-a2ef31a2bf02"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("b31a2760-bb3b-4201-8996-1c70d11f5ec3"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c184b210-da5f-47e8-967a-d8fa638f0a31"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c31b16a2-e698-417d-afe4-6db2a3293b7b"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c427cbc7-9aa4-4fa3-a2ab-144682fb6675"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c4a14691-9a53-4bd1-8e1f-92867361fef8"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c54effae-710f-4bd0-960d-615eb9693ec8"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("cb7df6d2-2d1a-4f80-9395-b85b9c474d23"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("ccdbd9f7-edc3-4079-a952-030bce89ac91"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("d0bb6bf7-a451-4ee5-bfbc-d9c9ff705c00"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("d2e7c7d7-e8ca-40f5-9451-2aa6b130e012"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("d6c63920-fb34-4449-bf7b-51c744bfd8db"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("e77dfe02-29c4-4d66-92e2-7790b2469078"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("eb5cee58-96b3-40a6-9730-23b033237dc1"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("ed84f224-08a9-4351-b74c-1a0e89df6266"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("ee96c35c-16a1-4d49-81ee-9c6da2d45c30"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("f0cd9589-0d2c-45cd-ba6d-fc30fefb24f6"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("f39f9f83-7c3b-4072-b03b-731e7a5b2c41"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("f668724c-5708-4926-a48d-f9d4d5fb6574"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("f903f5e1-bd61-4bdf-8103-1a7a9fed552a"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("f9574bd2-41eb-4e9b-87da-4e30a719e76b"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("fb5aa51d-7cce-49e0-8011-85b928ca858f"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("01359071-ba48-49ab-9c6f-d074cacd1da7"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("09af72e4-c5bf-479e-9e2a-de305084607d"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("2d9e6050-8285-47f7-980d-c16cb35390fa"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("54087128-111d-425d-bc9f-6333e0521c0f"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("910d0153-c665-40a4-90fd-7ea6fd2cde02"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("a7783104-39de-40ef-8737-bc6e51f7c908"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("b38da0e7-ac40-4a43-93eb-c0aa5a815616"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("b628a8f1-525e-4b6c-9f34-4c4efd9e3834"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("c4867bc1-042c-4bf9-bec8-ecfa433bba79"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("ef0eac0d-0ac9-41cc-92f1-8441b2084e93"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("c7fc1e61-a6cb-4b1e-8dbe-d2ba665da721"));

            migrationBuilder.DeleteData(
                table: "exam",
                keyColumn: "id",
                keyValue: new Guid("332e41bb-32b2-42cd-949d-771a95e1bf3b"));

            migrationBuilder.DeleteData(
                table: "exam",
                keyColumn: "id",
                keyValue: new Guid("d83d3b2e-0d98-4401-963c-e89e336347ca"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("1876288b-0c0d-46df-8ff6-2ea5ba39b38b"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("25fa20c6-cc6f-410b-a52b-7de660f71503"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("2f4912ef-4377-4c3d-8309-ec0729b2331d"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("42d3a1b3-31fe-4f77-a5e5-7beeff069b86"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("46e26cdc-d21b-46e1-83d3-afc9383bb73a"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("4ea7b7fd-c68c-4b51-8994-262435f6ce16"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("554bf311-5862-4cd7-a410-3e3fd3185925"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("80a67e1d-5325-4260-9b3f-ee5ff8d826c4"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("97d289c4-1666-4efc-b7bd-990841399657"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("a205fd1d-0d3c-4bd7-a52b-ef12cc1fa186"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("ac696226-fe4f-485f-9787-eef28afbe818"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c74fc043-5ed3-4f54-9541-f480404df0ca"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("c9aae1d6-1a53-4b29-9e1a-721c34d99825"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("d93cc0c2-50d2-4ad4-92ae-8f8f3d32b323"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("e98d3525-27d5-47c7-b207-e635865dfa35"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("10dcca1d-53f1-4969-8f59-39ac9960c173"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("3a619a5e-7b18-4786-9f0d-735838963e8a"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("744b7ae2-58b0-4411-8be1-89d875500b55"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("8f4372b0-e727-41e0-9fbf-06a728e0f029"));

            migrationBuilder.DeleteData(
                table: "question",
                keyColumn: "id",
                keyValue: new Guid("92c609e1-70ef-4e87-9853-263f004c6bf5"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("6251c095-131c-41f9-aff9-7b341fe82a21"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("67e0ce84-a2fd-4bf5-ac79-abfe1cdf923e"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("d1e5050d-29a8-4e6b-a590-06abd9635358"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("fbb3e0c2-1688-41d8-9108-2478c7b5daa0"));

            migrationBuilder.DeleteData(
                table: "exam",
                keyColumn: "id",
                keyValue: new Guid("b1d7ab79-d1ec-424b-9aff-e93e5d8f55c3"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("01f09d44-f2db-44ae-9d41-83722ae12ca8"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("0dfcd378-ff58-4db4-8b68-975ccd76739f"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("0edb1e54-ff68-4787-87da-5816d227d4cf"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("23b37272-80a6-4c42-9146-1110c59b963d"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("306c3be7-abdf-4194-bfa3-b6f64208b353"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("6bdb60b5-c1cb-427e-96c1-902bc29dc2f3"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("98d26dd7-7fa3-4441-8a1d-2f3c327a2e34"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("9cc1ecb8-c5db-4ef8-8905-46c2b8964b09"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("aff16625-074b-4237-8994-2cde3e9f8fb6"));

            migrationBuilder.DeleteData(
                table: "subject",
                keyColumn: "id",
                keyValue: new Guid("5328674a-6706-439e-b2b1-a0a3e7f3d9fe"));

            migrationBuilder.DeleteData(
                table: "subject",
                keyColumn: "id",
                keyValue: new Guid("5e194cb3-b0fd-4e56-aa03-e259a63d04fa"));

            migrationBuilder.DeleteData(
                table: "subject",
                keyColumn: "id",
                keyValue: new Guid("c61c07c1-2927-47bb-b37a-e22cd8d1a6de"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("0ecc3300-b64f-442a-9928-e59fccbe086a"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("1dc1ba88-4416-4757-8fb5-45aac05aa28c"));

            migrationBuilder.DeleteData(
                table: "supporting_text",
                keyColumn: "id",
                keyValue: new Guid("82e9e1db-aa45-47f3-a352-f335ce01e137"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("228d72d9-19a6-4746-8bc7-d2b519eda473"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("53e3591f-537b-4256-aa9d-094c80884970"));

            migrationBuilder.DeleteData(
                table: "incremented_text",
                keyColumn: "id",
                keyValue: new Guid("de582164-1461-4bbe-98fe-7ad26bbc73fb"));

            migrationBuilder.DeleteData(
                table: "subject",
                keyColumn: "id",
                keyValue: new Guid("9c7835a3-3f71-4d06-990e-3149e87a7727"));

            migrationBuilder.AddColumn<Guid>(
                name: "child_exam_module_id",
                table: "exam",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "exam",
                columns: new[] { "id", "child_exam_module_id", "created_date", "exam_model", "exam_number", "exam_topic", "exam_type", "father_exam_module_id", "removed_date", "updated_date" },
                values: new object[,]
                {
                    { new Guid("292e0d58-73c2-4d0c-a38f-695c455a427e"), null, new DateTime(2021, 8, 24, 19, 19, 43, 449, DateTimeKind.Local).AddTicks(5178), 0, 1, 3, 0, null, null, new DateTime(2021, 8, 24, 19, 19, 43, 449, DateTimeKind.Local).AddTicks(5186) },
                    { new Guid("3c883c88-efd7-4344-961c-89bc61d78839"), null, new DateTime(2021, 8, 24, 19, 19, 43, 449, DateTimeKind.Local).AddTicks(8832), 1, 1, 3, 1, null, null, new DateTime(2021, 8, 24, 19, 19, 43, 449, DateTimeKind.Local).AddTicks(8833) },
                    { new Guid("0c39038e-2331-44b5-a4d6-c6ea8b31265c"), null, new DateTime(2021, 8, 24, 19, 19, 43, 449, DateTimeKind.Local).AddTicks(8851), 1, 2, 3, 1, null, null, new DateTime(2021, 8, 24, 19, 19, 43, 449, DateTimeKind.Local).AddTicks(8852) }
                });

            migrationBuilder.InsertData(
                table: "incremented_text",
                columns: new[] { "id", "content", "increments" },
                values: new object[,]
                {
                    { new Guid("d67d3f86-5461-4e06-9921-11d3a9d88072"), "8,32", null },
                    { new Guid("4009b1d1-9765-4a94-a50c-6269a0adeef3"), "4,64", null },
                    { new Guid("e93702e1-d8a1-4783-9313-fb7dbd63d2aa"), "maior que 131", null },
                    { new Guid("657151f5-2625-49ef-bfc5-8b505394952d"), "entre 130 e 131.", null },
                    { new Guid("c6a59263-16f6-4e2a-9508-6b584d8075d9"), "entre 129 e 130.", null },
                    { new Guid("7301483a-cafd-4197-ade4-1af383bae080"), "entre 128 e 129.", null },
                    { new Guid("14f05f80-89ee-4331-b6b2-7a0f3c425855"), "menor do que 128.", null },
                    { new Guid("9da93404-c7fa-4a5c-867b-7c63528cb31d"), "60°", null },
                    { new Guid("a43352af-c21b-43b3-8270-a354249a6948"), "30°", null },
                    { new Guid("36f66b67-b31f-4d98-8e82-8e246273fbb7"), "45°", null },
                    { new Guid("c79e3108-3c81-4de8-9578-baf91981f1f4"), "Testeee2", null },
                    { new Guid("ca8a53d6-82da-489c-bd64-ca6730429681"), "Teste", null },
                    { new Guid("b85e2a6c-5110-46a0-8512-0b7845deac73"), "60°", null },
                    { new Guid("8f4423d4-cc3a-43e0-b3fa-c2abb605aa30"), "30°", null },
                    { new Guid("418f331a-5bf6-45b7-a39b-36363583402d"), "45°", null },
                    { new Guid("2be9fe46-c453-45a7-96f2-fbf2ddb61f74"), "22,5°", null },
                    { new Guid("65d0632e-a28b-4f3d-b648-1605da2eaf27"), "15°", null },
                    { new Guid("9b125ae2-e56c-45d8-8bfa-5699f70dd09c"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("b1675914-b577-42df-ac5d-c25ae5f37d69"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("c3aa9184-f2b3-462e-bea3-26a7e9898682"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("f2aee079-2fc8-4249-931a-8fa9eb56c0b6"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("109144c7-bf60-41a7-823c-5d49dbe50fd7"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("cfd8f659-42b7-41ca-a329-3bfe5056dafc"), "6.62", null },
                    { new Guid("976ff0c9-5736-4957-b730-372ef45564bd"), "3,68", null },
                    { new Guid("e8edc645-e5f1-4aab-9ce9-36dac1e470de"), "5,34", null },
                    { new Guid("614a5e35-aeb4-474c-9989-a81f76fc1259"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("793a0130-0195-4087-ba0c-4d5f4a6166dd"), "TEXTO DE APOIO SIMPLES SEM INCREMENTO", null },
                    { new Guid("76bcb2f0-060d-4513-a5b8-934098434412"), "TEXTO DE APOIO SIMPLES SEM INCREMENTO", null },
                    { new Guid("ab349696-1ed8-4d9a-93ca-4428576142c8"), "TEXTO DE APOIO DE PORTUGUES COM IMAGEM \r\n {0}", "[{\"Index\":0,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("b426c1c5-b0c9-49b5-b28f-200fe814558f"), "TEXTO DE APOIO DE PORTUGUES COM IMAGEM \r\n {0}", "[{\"Index\":0,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("fa14a1e1-4626-4c02-af13-e5b8d90118e2"), "TEXTO DE APOIO DE PORTUGUES COM IMAGEM \r\n {0}", "[{\"Index\":0,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("5fb2967f-bb49-4a75-9942-ab615f920d0c"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("dac1fa55-dbda-4ea0-ad0e-44c8a85f2976"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("c4681e37-e3cb-4de5-888d-fa333782022d"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("79334c4a-cee6-4328-8258-97b984520729"), "60°", null },
                    { new Guid("052395e0-195d-4fd6-90df-8bb80dd61959"), "30°", null },
                    { new Guid("85fb3f46-1200-4119-b0fb-4d305aee946b"), "5,34", null },
                    { new Guid("350d29a8-90de-4869-9e94-ed07c2083825"), "45°", null },
                    { new Guid("037974ac-58e4-4a1c-80d9-686caefbf614"), "Teste", null },
                    { new Guid("10648921-532c-41ba-bee0-b4a0975e56bb"), "60°", null },
                    { new Guid("fecc3c4f-83bb-480e-8ce3-639d8cbaa600"), "30°", null },
                    { new Guid("028b49ab-ff8d-4151-afec-38e1e659c584"), "45°", null },
                    { new Guid("f3baca77-d4ac-4f98-a186-28ac524182e3"), "22,5°", null },
                    { new Guid("98a7148b-6bb5-4795-b067-a5740a15be24"), "15°", null },
                    { new Guid("7106ba6c-f0cb-4510-b8cb-0419d41a27d5"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("7d11008d-b0c2-4021-98d8-261518c6ff7b"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("9e097f71-96ae-4325-acc1-5dc84ef2b18a"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("80910323-ecae-414f-9417-12286ab923ea"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("eee25dd0-14c4-43ba-8b50-ead27fe08b22"), "Testeee2", null },
                    { new Guid("a0c1f048-f0b6-455e-a5ec-0a7fa8d7cab9"), "3,68", null },
                    { new Guid("191fc247-df3f-45cc-90dd-1a6b1ea37a14"), "8,32", null },
                    { new Guid("6d7f7788-04ec-474a-a54c-b121da11038a"), "TEXTO DE APOIO SIMPLES SEM INCREMENTO", null },
                    { new Guid("c042d1dc-1cfb-49e7-8ee1-037f485f8920"), "4,64", null },
                    { new Guid("381b97c0-ef39-4b9f-a83e-1864f8326f6a"), "maior que 131", null },
                    { new Guid("d03b7c91-e4aa-48c6-8972-efd8cdf25476"), "entre 130 e 131.", null },
                    { new Guid("6535c1f4-8edc-4676-89f5-091b23beeaf0"), "entre 129 e 130.", null },
                    { new Guid("c346d4c7-9416-44f0-9b81-c802f2192d0d"), "entre 128 e 129.", null },
                    { new Guid("20536bdf-8f81-477d-84c4-4b68e30964b4"), "menor do que 128.", null },
                    { new Guid("d1e85694-d789-4bfb-9f00-7efd62a41125"), "Enunciado teste com equacao {0} e imagem:  \r\n{1}\r\n  para teste", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("7530c676-0ddb-4d46-9826-f4c99a78c244"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("b5c568ea-4fd7-465e-84a4-a78d582476f9"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("7df1a7f6-a717-4ef0-8e14-2c9d51850419"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("e510394e-bdef-4b9e-9b2a-375ae3dfe19d"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("eb386291-41c9-4f11-b3f0-3b0d0fd91a2f"), "Enunciado teste com equacao {0} e imagem:  \r\n{1}\r\n  para teste", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("09c0d02a-cf74-4d04-bed0-2a4051e4b53b"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("fbb45eae-3d55-436f-976a-03d7d33774b0"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("26b57fba-4c70-4cc7-8f5d-3a90399f27ee"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("5c0b58fd-c7b0-4330-81ea-2ab552549c4c"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("6ac67cd7-a320-466d-b215-36c9d808d9e2"), "Enunciado teste com equacao {0} e imagem:  \r\n{1}\r\n  para teste", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1}]" },
                    { new Guid("5fc46a97-9abe-4a7c-afac-0a63de219c3b"), "Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png\",\"Type\":1},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("ebb3cc67-2bda-4d13-89e0-a7f57abf9cdd"), "Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ", null },
                    { new Guid("524a49aa-d2f3-45f8-be49-82e253466c67"), "Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":3,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":4,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("e9111dc3-3be6-4ade-b3c3-71cbc9e663ea"), "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente", "[{\"Index\":0,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>\",\"Type\":0},{\"Index\":1,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>\",\"Type\":0},{\"Index\":2,\"Value\":\"<mml:math xmlns:mml=\\\"http://www.w3.org/1998/Math/MathML\\\" xmlns:m=\\\"http://schemas.openxmlformats.org/officeDocument/2006/math\\\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>\",\"Type\":0}]" },
                    { new Guid("812def4d-5a00-46e2-b0d4-8820676f65fd"), "6.62", null },
                    { new Guid("d6abb460-4201-4d4f-8fe0-ecaed255f35c"), "6.62", null },
                    { new Guid("ce627606-b41f-4896-a311-6783f8c27340"), "8,32", null },
                    { new Guid("f2e1c5ba-2fd7-438d-941a-4b306098b32d"), "5,34", null },
                    { new Guid("ee1a5d29-920b-44bf-a986-baa5182651cb"), "4,64", null },
                    { new Guid("47fcae00-5bb9-4bc5-8594-db07833f88e4"), "maior que 131", null },
                    { new Guid("ff17e4be-5b28-45dc-bcad-611c3fce7c74"), "entre 130 e 131.", null },
                    { new Guid("43ce1afb-92dd-4080-9c82-a123689c13cb"), "entre 129 e 130.", null },
                    { new Guid("73adf393-0430-4c2c-a151-e1054d0b2a81"), "entre 128 e 129.", null },
                    { new Guid("e137ed45-89c6-43e8-9bf9-cffab21fcd72"), "menor do que 128.", null },
                    { new Guid("6b21c0cd-1db9-48b8-ad59-42f8adad9ac2"), "60°", null },
                    { new Guid("c4eb295a-290f-41af-a698-d693654ee8d4"), "30°", null },
                    { new Guid("51a11976-7e6d-48c6-bd0a-54e3787d43bf"), "3,68", null },
                    { new Guid("74f78f61-7fad-4755-82e2-8a368b275cc7"), "Testeee2", null },
                    { new Guid("352a4af7-1ef8-464e-84ca-775e9a4d0039"), "45°", null },
                    { new Guid("97dac685-3477-4875-a33b-6e8c349e9083"), "60°", null },
                    { new Guid("c5db1648-1e0c-48d5-bed1-c7e68256a627"), "30°", null },
                    { new Guid("91173c7c-aabb-4887-a567-3a666d0302a2"), "45°", null },
                    { new Guid("49c623cb-29e5-4f7e-bf8d-962db0fa14bc"), "22,5°", null },
                    { new Guid("f4b2b8fa-6317-4bb6-8810-4808a5fb1bc5"), "15°", null },
                    { new Guid("b8031b9d-bda3-45fb-b4fa-108c116fecd4"), "E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null },
                    { new Guid("bb05ca6a-f303-41ec-b4c8-b44536c23575"), "Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null },
                    { new Guid("82a599ac-c3c2-475f-9f9b-279546d7ccbf"), "As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null },
                    { new Guid("dc095436-10a0-4994-b62a-2d40cce52921"), "O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null },
                    { new Guid("0096f9d7-74ce-4aa7-8a2f-3d6a3f7dde1e"), "O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null },
                    { new Guid("993e21b7-50e0-4efe-b136-cc3885c46858"), "Teste", null }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("271fed33-f461-4445-aa6d-960cf69d69b5"), new DateTime(2021, 8, 24, 19, 19, 43, 440, DateTimeKind.Local).AddTicks(889), "Polinômios", null, null, new DateTime(2021, 8, 24, 19, 19, 43, 440, DateTimeKind.Local).AddTicks(890) },
                    { new Guid("0c38ec1e-ba98-4542-bcd0-8746b3c2b831"), new DateTime(2021, 8, 24, 19, 19, 43, 440, DateTimeKind.Local).AddTicks(879), "Português", null, null, new DateTime(2021, 8, 24, 19, 19, 43, 440, DateTimeKind.Local).AddTicks(884) },
                    { new Guid("255c114c-0542-45a1-8bd4-7da73f56075d"), new DateTime(2021, 8, 24, 19, 19, 43, 439, DateTimeKind.Local).AddTicks(9559), "Matemática", null, null, new DateTime(2021, 8, 24, 19, 19, 43, 440, DateTimeKind.Local).AddTicks(41) }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "birth_date", "cognito_user_id", "created_date", "email", "gender", "name", "phone_number", "removed_date", "updated_date", "user_type", "was_accepted_terms", "address.cep", "address.city", "address.neighborhood", "address.state", "address.street" },
                values: new object[] { new Guid("2fd5f106-fc04-492a-b052-f5ab05feb480"), new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e32ca6c-2a66-4ea6-a0c4-cf655dab5191"), new DateTime(2021, 8, 24, 19, 19, 43, 448, DateTimeKind.Local).AddTicks(5296), "sacchitiellogiovanni@gmail.com", "Masculino", "Giovanni Sacchitiello", "11991392711", null, new DateTime(2021, 8, 24, 19, 19, 43, 448, DateTimeKind.Local).AddTicks(5314), 0, false, "03320020", "São Paulo", "Carrão", "SP", "Rua antonio ciucio" });

            migrationBuilder.InsertData(
                table: "exam_period",
                columns: new[] { "id", "close_date", "exam_id", "open_date" },
                values: new object[,]
                {
                    { new Guid("acd74f68-96bd-4478-973b-16b1ba36e59e"), new DateTime(2021, 8, 28, 12, 0, 0, 0, DateTimeKind.Local), new Guid("292e0d58-73c2-4d0c-a38f-695c455a427e"), new DateTime(2021, 8, 28, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("f25f3472-e199-48b6-8a10-f54a5334df70"), new DateTime(2021, 8, 29, 12, 0, 0, 0, DateTimeKind.Local), new Guid("292e0d58-73c2-4d0c-a38f-695c455a427e"), new DateTime(2021, 8, 29, 10, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("9e2b3121-d2f5-4b1d-8c51-767e01202e4b"), new DateTime(2021, 8, 24, 23, 19, 43, 449, DateTimeKind.Local).AddTicks(8790), new Guid("3c883c88-efd7-4344-961c-89bc61d78839"), new DateTime(2021, 8, 24, 19, 19, 43, 449, DateTimeKind.Local).AddTicks(8790) },
                    { new Guid("98350749-7032-4bfa-9ba8-058966533544"), new DateTime(2021, 8, 25, 21, 19, 43, 449, DateTimeKind.Local).AddTicks(8790), new Guid("3c883c88-efd7-4344-961c-89bc61d78839"), new DateTime(2021, 8, 25, 19, 19, 43, 449, DateTimeKind.Local).AddTicks(8790) },
                    { new Guid("16206306-a4bc-47bd-a1a2-925a528d1728"), new DateTime(2021, 8, 22, 21, 19, 43, 449, DateTimeKind.Local).AddTicks(8836), new Guid("0c39038e-2331-44b5-a4d6-c6ea8b31265c"), new DateTime(2021, 8, 22, 19, 19, 43, 449, DateTimeKind.Local).AddTicks(8836) },
                    { new Guid("7207a822-1c99-47ee-86c5-ea618d2a844d"), new DateTime(2021, 8, 23, 21, 19, 43, 449, DateTimeKind.Local).AddTicks(8836), new Guid("0c39038e-2331-44b5-a4d6-c6ea8b31265c"), new DateTime(2021, 8, 23, 19, 19, 43, 449, DateTimeKind.Local).AddTicks(8836) }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "supporting_text_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("f4ee07b8-71a5-404d-b796-62b47eb83fa2"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6023), new Guid("eb386291-41c9-4f11-b3f0-3b0d0fd91a2f"), new Guid("3c883c88-efd7-4344-961c-89bc61d78839"), 4, null, new Guid("271fed33-f461-4445-aa6d-960cf69d69b5"), null, new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6024) },
                    { new Guid("51def46d-4554-4ea8-86f0-bf6878c1465e"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6127), new Guid("d1e85694-d789-4bfb-9f00-7efd62a41125"), new Guid("0c39038e-2331-44b5-a4d6-c6ea8b31265c"), 4, null, new Guid("271fed33-f461-4445-aa6d-960cf69d69b5"), null, new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6128) },
                    { new Guid("3b54aad1-f948-4b51-8382-bde3050bee4b"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5952), new Guid("6ac67cd7-a320-466d-b215-36c9d808d9e2"), new Guid("292e0d58-73c2-4d0c-a38f-695c455a427e"), 4, null, new Guid("271fed33-f461-4445-aa6d-960cf69d69b5"), null, new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5953) }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "id", "created_date", "name", "removed_date", "subject_father_id", "updated_date" },
                values: new object[] { new Guid("bb7c03f7-5f68-4f09-a7af-821492ccfef4"), new DateTime(2021, 8, 24, 19, 19, 43, 440, DateTimeKind.Local).AddTicks(886), "Porcentagem", null, new Guid("255c114c-0542-45a1-8bd4-7da73f56075d"), new DateTime(2021, 8, 24, 19, 19, 43, 440, DateTimeKind.Local).AddTicks(887) });

            migrationBuilder.InsertData(
                table: "supporting_text",
                columns: new[] { "id", "content_id" },
                values: new object[,]
                {
                    { new Guid("ae04d6b9-937a-4e2c-9913-6b22a29efe3d"), new Guid("793a0130-0195-4087-ba0c-4d5f4a6166dd") },
                    { new Guid("6cc46676-399a-44ad-90c9-cc445fc18242"), new Guid("c4681e37-e3cb-4de5-888d-fa333782022d") },
                    { new Guid("745ff9b2-280f-43a1-bbfe-5dc2fbcc6d88"), new Guid("dac1fa55-dbda-4ea0-ad0e-44c8a85f2976") },
                    { new Guid("b0a3dd57-7047-4668-83ea-88c1235ea1ae"), new Guid("5fb2967f-bb49-4a75-9942-ab615f920d0c") },
                    { new Guid("4e5bb375-1a43-4b89-b12c-161da8563c39"), new Guid("fa14a1e1-4626-4c02-af13-e5b8d90118e2") },
                    { new Guid("ecc47b98-fc2b-4e2e-8bb7-71736303b1f0"), new Guid("b426c1c5-b0c9-49b5-b28f-200fe814558f") },
                    { new Guid("3c9b0829-487a-4401-8f51-22e7d8383b8c"), new Guid("ab349696-1ed8-4d9a-93ca-4428576142c8") },
                    { new Guid("73deb30c-8d71-4aba-b7ea-5a749f741b64"), new Guid("76bcb2f0-060d-4513-a5b8-934098434412") },
                    { new Guid("a7a1267b-e97c-43e6-aab7-b1dcdaf2b29b"), new Guid("6d7f7788-04ec-474a-a54c-b121da11038a") }
                });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("caf47ca8-0d13-4d12-ba24-13d57d5ed2bd"), 0, true, new Guid("3b54aad1-f948-4b51-8382-bde3050bee4b"), new Guid("993e21b7-50e0-4efe-b136-cc3885c46858") },
                    { new Guid("30401158-612c-4a98-a011-f7ed5df85e2a"), 4, false, new Guid("51def46d-4554-4ea8-86f0-bf6878c1465e"), new Guid("79334c4a-cee6-4328-8258-97b984520729") },
                    { new Guid("a0359eb9-6a7a-43b2-bff4-baf38a21fdb4"), 2, false, new Guid("51def46d-4554-4ea8-86f0-bf6878c1465e"), new Guid("350d29a8-90de-4869-9e94-ed07c2083825") },
                    { new Guid("0956be28-45f2-4748-a4b9-333a733b3c0c"), 1, false, new Guid("51def46d-4554-4ea8-86f0-bf6878c1465e"), new Guid("eee25dd0-14c4-43ba-8b50-ead27fe08b22") },
                    { new Guid("fdc74669-41d8-4cbb-a974-5b760965b37b"), 0, true, new Guid("51def46d-4554-4ea8-86f0-bf6878c1465e"), new Guid("037974ac-58e4-4a1c-80d9-686caefbf614") },
                    { new Guid("76698ba0-b8ba-4db7-aafc-2cab86071416"), 4, false, new Guid("f4ee07b8-71a5-404d-b796-62b47eb83fa2"), new Guid("9da93404-c7fa-4a5c-867b-7c63528cb31d") },
                    { new Guid("d0d6638d-95e0-451c-a96b-5f47a17302bf"), 3, false, new Guid("f4ee07b8-71a5-404d-b796-62b47eb83fa2"), new Guid("a43352af-c21b-43b3-8270-a354249a6948") },
                    { new Guid("c71b7028-63f1-4034-b2a0-5fbef1ace034"), 3, false, new Guid("51def46d-4554-4ea8-86f0-bf6878c1465e"), new Guid("052395e0-195d-4fd6-90df-8bb80dd61959") },
                    { new Guid("711e4d66-aa38-446e-9069-adb4a9a903fb"), 1, false, new Guid("f4ee07b8-71a5-404d-b796-62b47eb83fa2"), new Guid("c79e3108-3c81-4de8-9578-baf91981f1f4") },
                    { new Guid("2be94c11-3696-4756-87f1-defaa33b40a4"), 0, true, new Guid("f4ee07b8-71a5-404d-b796-62b47eb83fa2"), new Guid("ca8a53d6-82da-489c-bd64-ca6730429681") },
                    { new Guid("4cd84e7c-8a34-4859-a706-cfa11c89902f"), 4, false, new Guid("3b54aad1-f948-4b51-8382-bde3050bee4b"), new Guid("6b21c0cd-1db9-48b8-ad59-42f8adad9ac2") },
                    { new Guid("7e4921a1-380b-44ac-a703-f0017607c7e7"), 3, false, new Guid("3b54aad1-f948-4b51-8382-bde3050bee4b"), new Guid("c4eb295a-290f-41af-a698-d693654ee8d4") },
                    { new Guid("82b74127-5353-4ee6-bb54-21b6b31918f8"), 2, false, new Guid("3b54aad1-f948-4b51-8382-bde3050bee4b"), new Guid("352a4af7-1ef8-464e-84ca-775e9a4d0039") },
                    { new Guid("b2b1c61a-db61-4a88-8577-2902d42d3ec4"), 1, false, new Guid("3b54aad1-f948-4b51-8382-bde3050bee4b"), new Guid("74f78f61-7fad-4755-82e2-8a368b275cc7") },
                    { new Guid("9c193b1f-2f40-46d9-b19c-71d368dc1fdd"), 2, false, new Guid("f4ee07b8-71a5-404d-b796-62b47eb83fa2"), new Guid("36f66b67-b31f-4d98-8e82-8e246273fbb7") }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "created_date", "enunciated_id", "exam_id", "index", "removed_date", "subject_id", "supporting_text_id", "updated_date" },
                values: new object[,]
                {
                    { new Guid("f255c080-acb5-4416-ab91-19344a69e7d9"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6087), new Guid("7df1a7f6-a717-4ef0-8e14-2c9d51850419"), new Guid("0c39038e-2331-44b5-a4d6-c6ea8b31265c"), 1, null, new Guid("bb7c03f7-5f68-4f09-a7af-821492ccfef4"), new Guid("a7a1267b-e97c-43e6-aab7-b1dcdaf2b29b"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6088) },
                    { new Guid("fee1b3fa-30f6-4f80-8b2a-1be58a055afd"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6072), new Guid("e510394e-bdef-4b9e-9b2a-375ae3dfe19d"), new Guid("0c39038e-2331-44b5-a4d6-c6ea8b31265c"), 0, null, new Guid("255c114c-0542-45a1-8bd4-7da73f56075d"), new Guid("a7a1267b-e97c-43e6-aab7-b1dcdaf2b29b"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6072) },
                    { new Guid("ac8e2eda-a856-48d5-a824-61cc951d3e86"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6008), new Guid("09c0d02a-cf74-4d04-bed0-2a4051e4b53b"), new Guid("3c883c88-efd7-4344-961c-89bc61d78839"), 3, null, new Guid("bb7c03f7-5f68-4f09-a7af-821492ccfef4"), new Guid("ae04d6b9-937a-4e2c-9913-6b22a29efe3d"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6009) },
                    { new Guid("66755edb-dc2e-4204-99eb-abd34c0bbae0"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5982), new Guid("26b57fba-4c70-4cc7-8f5d-3a90399f27ee"), new Guid("3c883c88-efd7-4344-961c-89bc61d78839"), 1, null, new Guid("bb7c03f7-5f68-4f09-a7af-821492ccfef4"), new Guid("ae04d6b9-937a-4e2c-9913-6b22a29efe3d"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5983) },
                    { new Guid("ce66fa6d-8554-4f0e-8219-77de48985bfc"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5938), new Guid("5fc46a97-9abe-4a7c-afac-0a63de219c3b"), new Guid("292e0d58-73c2-4d0c-a38f-695c455a427e"), 3, null, new Guid("bb7c03f7-5f68-4f09-a7af-821492ccfef4"), new Guid("73deb30c-8d71-4aba-b7ea-5a749f741b64"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5939) },
                    { new Guid("634ef7a8-451b-4e9c-9d4e-3fe453115e83"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5879), new Guid("ebb3cc67-2bda-4d13-89e0-a7f57abf9cdd"), new Guid("292e0d58-73c2-4d0c-a38f-695c455a427e"), 2, null, new Guid("0c38ec1e-ba98-4542-bcd0-8746b3c2b831"), new Guid("4e5bb375-1a43-4b89-b12c-161da8563c39"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5879) },
                    { new Guid("f3b19f35-b868-4993-b6af-c6b8c3eec55e"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5995), new Guid("fbb45eae-3d55-436f-976a-03d7d33774b0"), new Guid("3c883c88-efd7-4344-961c-89bc61d78839"), 2, null, new Guid("0c38ec1e-ba98-4542-bcd0-8746b3c2b831"), new Guid("ecc47b98-fc2b-4e2e-8bb7-71736303b1f0"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5996) },
                    { new Guid("655d9837-8c96-4637-aba1-3bd950b9538d"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5967), new Guid("5c0b58fd-c7b0-4330-81ea-2ab552549c4c"), new Guid("3c883c88-efd7-4344-961c-89bc61d78839"), 0, null, new Guid("255c114c-0542-45a1-8bd4-7da73f56075d"), new Guid("745ff9b2-280f-43a1-bbfe-5dc2fbcc6d88"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5967) },
                    { new Guid("6c99e014-6aec-4c1a-ad56-af72af4b8870"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(2721), new Guid("e9111dc3-3be6-4ade-b3c3-71cbc9e663ea"), new Guid("292e0d58-73c2-4d0c-a38f-695c455a427e"), 0, null, new Guid("255c114c-0542-45a1-8bd4-7da73f56075d"), new Guid("6cc46676-399a-44ad-90c9-cc445fc18242"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(2727) },
                    { new Guid("f6b88984-2e9e-4b1d-9ca6-b1baa6ebf001"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6100), new Guid("b5c568ea-4fd7-465e-84a4-a78d582476f9"), new Guid("0c39038e-2331-44b5-a4d6-c6ea8b31265c"), 2, null, new Guid("0c38ec1e-ba98-4542-bcd0-8746b3c2b831"), new Guid("a7a1267b-e97c-43e6-aab7-b1dcdaf2b29b"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6101) },
                    { new Guid("55a650b4-aede-4e66-b74e-0765b1d55847"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5858), new Guid("524a49aa-d2f3-45f8-be49-82e253466c67"), new Guid("292e0d58-73c2-4d0c-a38f-695c455a427e"), 1, null, new Guid("bb7c03f7-5f68-4f09-a7af-821492ccfef4"), new Guid("73deb30c-8d71-4aba-b7ea-5a749f741b64"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(5864) },
                    { new Guid("2988c2f8-f0a3-4379-9f44-2473716560b5"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6113), new Guid("7530c676-0ddb-4d46-9826-f4c99a78c244"), new Guid("0c39038e-2331-44b5-a4d6-c6ea8b31265c"), 3, null, new Guid("bb7c03f7-5f68-4f09-a7af-821492ccfef4"), new Guid("a7a1267b-e97c-43e6-aab7-b1dcdaf2b29b"), new DateTime(2021, 8, 24, 19, 19, 43, 441, DateTimeKind.Local).AddTicks(6114) }
                });

            migrationBuilder.InsertData(
                table: "alternative",
                columns: new[] { "id", "index", "is_correct", "question_id", "text_content_id" },
                values: new object[,]
                {
                    { new Guid("913e1c1e-858e-415f-9335-e7f7d868dfb6"), 4, false, new Guid("ce66fa6d-8554-4f0e-8219-77de48985bfc"), new Guid("97dac685-3477-4875-a33b-6e8c349e9083") },
                    { new Guid("9ccfbf94-5cd5-43b5-9eae-0e5194cbf920"), 1, false, new Guid("66755edb-dc2e-4204-99eb-abd34c0bbae0"), new Guid("191fc247-df3f-45cc-90dd-1a6b1ea37a14") },
                    { new Guid("0f80a1af-1156-45a3-a1df-989685c1403f"), 2, false, new Guid("66755edb-dc2e-4204-99eb-abd34c0bbae0"), new Guid("812def4d-5a00-46e2-b0d4-8820676f65fd") },
                    { new Guid("a7a6f9df-47d5-455a-8656-2ac6ab478183"), 3, false, new Guid("66755edb-dc2e-4204-99eb-abd34c0bbae0"), new Guid("a0c1f048-f0b6-455e-a5ec-0a7fa8d7cab9") },
                    { new Guid("bc7722aa-5340-4f67-9b34-311542b55214"), 4, false, new Guid("66755edb-dc2e-4204-99eb-abd34c0bbae0"), new Guid("85fb3f46-1200-4119-b0fb-4d305aee946b") },
                    { new Guid("ac66f2fe-ffa9-4a58-8438-9513048ad321"), 0, true, new Guid("ac8e2eda-a856-48d5-a824-61cc951d3e86"), new Guid("65d0632e-a28b-4f3d-b648-1605da2eaf27") },
                    { new Guid("033f8fe2-906c-41be-b261-2e872537885c"), 1, false, new Guid("ac8e2eda-a856-48d5-a824-61cc951d3e86"), new Guid("2be9fe46-c453-45a7-96f2-fbf2ddb61f74") },
                    { new Guid("7671463d-a2e6-46d9-8a03-53064a9eb90b"), 2, false, new Guid("ac8e2eda-a856-48d5-a824-61cc951d3e86"), new Guid("418f331a-5bf6-45b7-a39b-36363583402d") },
                    { new Guid("7ab68517-19b8-4d5b-8411-c62372be3bd0"), 3, false, new Guid("ac8e2eda-a856-48d5-a824-61cc951d3e86"), new Guid("8f4423d4-cc3a-43e0-b3fa-c2abb605aa30") },
                    { new Guid("605d5cd6-7483-45eb-a2da-165fd0f7bbc2"), 4, false, new Guid("ac8e2eda-a856-48d5-a824-61cc951d3e86"), new Guid("b85e2a6c-5110-46a0-8512-0b7845deac73") },
                    { new Guid("415f01db-507b-44ab-854b-6b47895a0ce8"), 0, true, new Guid("fee1b3fa-30f6-4f80-8b2a-1be58a055afd"), new Guid("14f05f80-89ee-4331-b6b2-7a0f3c425855") },
                    { new Guid("e57c2fe8-e2d7-4b08-8a0a-af3913191506"), 1, false, new Guid("fee1b3fa-30f6-4f80-8b2a-1be58a055afd"), new Guid("7301483a-cafd-4197-ade4-1af383bae080") },
                    { new Guid("3ab018e8-5d73-4464-b865-93034a521d39"), 2, false, new Guid("fee1b3fa-30f6-4f80-8b2a-1be58a055afd"), new Guid("c6a59263-16f6-4e2a-9508-6b584d8075d9") },
                    { new Guid("ac1e7795-1c0e-4a4e-96b0-d5031f120aa1"), 3, false, new Guid("fee1b3fa-30f6-4f80-8b2a-1be58a055afd"), new Guid("657151f5-2625-49ef-bfc5-8b505394952d") },
                    { new Guid("6322a5a0-90d4-4cd4-adca-e5e02fa20b7d"), 4, false, new Guid("fee1b3fa-30f6-4f80-8b2a-1be58a055afd"), new Guid("e93702e1-d8a1-4783-9313-fb7dbd63d2aa") },
                    { new Guid("bd9d380c-fcc1-43b8-ad84-13c132f3760c"), 0, true, new Guid("f255c080-acb5-4416-ab91-19344a69e7d9"), new Guid("4009b1d1-9765-4a94-a50c-6269a0adeef3") },
                    { new Guid("2d368d3b-65f6-4dc1-9fbd-b35547b43633"), 1, false, new Guid("f255c080-acb5-4416-ab91-19344a69e7d9"), new Guid("d67d3f86-5461-4e06-9921-11d3a9d88072") },
                    { new Guid("0dbc299f-d541-4973-8095-3bb235485c12"), 2, false, new Guid("f255c080-acb5-4416-ab91-19344a69e7d9"), new Guid("cfd8f659-42b7-41ca-a329-3bfe5056dafc") },
                    { new Guid("b44adc57-485b-443d-9f5a-b97bad5f5580"), 3, false, new Guid("f255c080-acb5-4416-ab91-19344a69e7d9"), new Guid("976ff0c9-5736-4957-b730-372ef45564bd") },
                    { new Guid("24eddcf7-dfc4-40c1-ba44-36850632b1b4"), 4, false, new Guid("f255c080-acb5-4416-ab91-19344a69e7d9"), new Guid("e8edc645-e5f1-4aab-9ce9-36dac1e470de") },
                    { new Guid("46441540-aa2c-40f4-9312-20ab49fffec7"), 0, true, new Guid("f6b88984-2e9e-4b1d-9ca6-b1baa6ebf001"), new Guid("614a5e35-aeb4-474c-9989-a81f76fc1259") },
                    { new Guid("0c889389-92ea-42b1-954d-eba83d0fbc36"), 1, false, new Guid("f6b88984-2e9e-4b1d-9ca6-b1baa6ebf001"), new Guid("80910323-ecae-414f-9417-12286ab923ea") },
                    { new Guid("24fd4a9c-1a9f-4b3f-a790-ddb1790190aa"), 2, false, new Guid("f6b88984-2e9e-4b1d-9ca6-b1baa6ebf001"), new Guid("9e097f71-96ae-4325-acc1-5dc84ef2b18a") },
                    { new Guid("3b432b20-3eb8-489e-80f9-f52ac62109a6"), 3, false, new Guid("f6b88984-2e9e-4b1d-9ca6-b1baa6ebf001"), new Guid("7d11008d-b0c2-4021-98d8-261518c6ff7b") },
                    { new Guid("bfe3a305-0bbf-4997-9483-385fcf1e400f"), 4, false, new Guid("f6b88984-2e9e-4b1d-9ca6-b1baa6ebf001"), new Guid("7106ba6c-f0cb-4510-b8cb-0419d41a27d5") },
                    { new Guid("1248908d-1b01-4757-b55b-08afab2efe95"), 0, true, new Guid("2988c2f8-f0a3-4379-9f44-2473716560b5"), new Guid("98a7148b-6bb5-4795-b067-a5740a15be24") },
                    { new Guid("0bda1b5b-9cb3-4aa2-a472-f2ab196988e2"), 1, false, new Guid("2988c2f8-f0a3-4379-9f44-2473716560b5"), new Guid("f3baca77-d4ac-4f98-a186-28ac524182e3") },
                    { new Guid("49677620-112a-41fe-ab8c-191b5154b60f"), 2, false, new Guid("2988c2f8-f0a3-4379-9f44-2473716560b5"), new Guid("028b49ab-ff8d-4151-afec-38e1e659c584") },
                    { new Guid("58f8db34-df67-42d5-ad17-9f9f744537b2"), 0, true, new Guid("66755edb-dc2e-4204-99eb-abd34c0bbae0"), new Guid("ee1a5d29-920b-44bf-a986-baa5182651cb") },
                    { new Guid("3410ab0c-ff3a-48c0-9f37-011b2fe8a934"), 3, false, new Guid("2988c2f8-f0a3-4379-9f44-2473716560b5"), new Guid("fecc3c4f-83bb-480e-8ce3-639d8cbaa600") },
                    { new Guid("89d42166-781d-4c6f-bf68-ccbde0ba43bf"), 4, false, new Guid("2988c2f8-f0a3-4379-9f44-2473716560b5"), new Guid("10648921-532c-41ba-bee0-b4a0975e56bb") },
                    { new Guid("b6845666-db8a-411c-957b-418578fbd9f0"), 2, false, new Guid("ce66fa6d-8554-4f0e-8219-77de48985bfc"), new Guid("91173c7c-aabb-4887-a567-3a666d0302a2") },
                    { new Guid("a967d9f0-00af-4e29-9590-3e88e6814b22"), 0, true, new Guid("6c99e014-6aec-4c1a-ad56-af72af4b8870"), new Guid("20536bdf-8f81-477d-84c4-4b68e30964b4") },
                    { new Guid("c0f1974c-f444-47dd-a7f4-c8c8c91e4a51"), 1, false, new Guid("6c99e014-6aec-4c1a-ad56-af72af4b8870"), new Guid("c346d4c7-9416-44f0-9b81-c802f2192d0d") },
                    { new Guid("454d70cf-2862-40d0-93d3-87c28430b6c5"), 2, false, new Guid("6c99e014-6aec-4c1a-ad56-af72af4b8870"), new Guid("6535c1f4-8edc-4676-89f5-091b23beeaf0") },
                    { new Guid("8cb5db6a-0442-4155-9d1b-e5e95176ceb1"), 3, false, new Guid("6c99e014-6aec-4c1a-ad56-af72af4b8870"), new Guid("d03b7c91-e4aa-48c6-8972-efd8cdf25476") },
                    { new Guid("797c74ab-4252-4396-98be-831d5e27c661"), 4, false, new Guid("6c99e014-6aec-4c1a-ad56-af72af4b8870"), new Guid("381b97c0-ef39-4b9f-a83e-1864f8326f6a") },
                    { new Guid("38f1adb5-2c77-4790-bdf1-d0167e3763cc"), 0, true, new Guid("655d9837-8c96-4637-aba1-3bd950b9538d"), new Guid("e137ed45-89c6-43e8-9bf9-cffab21fcd72") },
                    { new Guid("318b68e9-8b11-4165-9fc6-307e8fe387ed"), 1, false, new Guid("655d9837-8c96-4637-aba1-3bd950b9538d"), new Guid("73adf393-0430-4c2c-a151-e1054d0b2a81") },
                    { new Guid("0aa5ffb8-c55a-48f2-af11-1ba6875bf70a"), 2, false, new Guid("655d9837-8c96-4637-aba1-3bd950b9538d"), new Guid("43ce1afb-92dd-4080-9c82-a123689c13cb") },
                    { new Guid("dacc8008-9930-4261-a460-2f0c2e4a182c"), 3, false, new Guid("655d9837-8c96-4637-aba1-3bd950b9538d"), new Guid("ff17e4be-5b28-45dc-bcad-611c3fce7c74") },
                    { new Guid("d5ed1616-fcee-4797-89da-e9bdce289f63"), 4, false, new Guid("655d9837-8c96-4637-aba1-3bd950b9538d"), new Guid("47fcae00-5bb9-4bc5-8594-db07833f88e4") },
                    { new Guid("2f309afb-68ac-403e-a18a-daea73960f40"), 0, true, new Guid("634ef7a8-451b-4e9c-9d4e-3fe453115e83"), new Guid("0096f9d7-74ce-4aa7-8a2f-3d6a3f7dde1e") },
                    { new Guid("76494bc6-e642-44ad-9f18-77ce61aab096"), 1, false, new Guid("634ef7a8-451b-4e9c-9d4e-3fe453115e83"), new Guid("dc095436-10a0-4994-b62a-2d40cce52921") },
                    { new Guid("d85ab6fb-70f0-4974-b506-402fcb1a10a5"), 2, false, new Guid("634ef7a8-451b-4e9c-9d4e-3fe453115e83"), new Guid("82a599ac-c3c2-475f-9f9b-279546d7ccbf") },
                    { new Guid("e12da43e-87ac-49e7-9de9-a3bdd610ab50"), 3, false, new Guid("634ef7a8-451b-4e9c-9d4e-3fe453115e83"), new Guid("bb05ca6a-f303-41ec-b4c8-b44536c23575") },
                    { new Guid("415530ea-ee2c-43d7-9527-819a7e727c66"), 4, false, new Guid("634ef7a8-451b-4e9c-9d4e-3fe453115e83"), new Guid("b8031b9d-bda3-45fb-b4fa-108c116fecd4") },
                    { new Guid("afd076a9-1259-4e79-8f10-c5235e8abe28"), 0, true, new Guid("f3b19f35-b868-4993-b6af-c6b8c3eec55e"), new Guid("109144c7-bf60-41a7-823c-5d49dbe50fd7") },
                    { new Guid("a9a2b0b5-a1ba-4a22-a44d-fd61100d7247"), 1, false, new Guid("f3b19f35-b868-4993-b6af-c6b8c3eec55e"), new Guid("f2aee079-2fc8-4249-931a-8fa9eb56c0b6") },
                    { new Guid("7b20e11c-f204-43f9-b4c9-9ee083c4411e"), 2, false, new Guid("f3b19f35-b868-4993-b6af-c6b8c3eec55e"), new Guid("c3aa9184-f2b3-462e-bea3-26a7e9898682") },
                    { new Guid("af8df48a-ffea-4f26-bf9b-cdd6c33844d6"), 3, false, new Guid("f3b19f35-b868-4993-b6af-c6b8c3eec55e"), new Guid("b1675914-b577-42df-ac5d-c25ae5f37d69") },
                    { new Guid("37c96d05-5c96-4244-b21f-97d559fcc5f4"), 4, false, new Guid("f3b19f35-b868-4993-b6af-c6b8c3eec55e"), new Guid("9b125ae2-e56c-45d8-8bfa-5699f70dd09c") },
                    { new Guid("378494a1-d650-4d44-b24b-7f19eabff388"), 0, true, new Guid("55a650b4-aede-4e66-b74e-0765b1d55847"), new Guid("c042d1dc-1cfb-49e7-8ee1-037f485f8920") },
                    { new Guid("09747ea5-8ad1-4c29-8073-2b0c073ba730"), 1, false, new Guid("55a650b4-aede-4e66-b74e-0765b1d55847"), new Guid("ce627606-b41f-4896-a311-6783f8c27340") },
                    { new Guid("7fb87752-aef1-4c2b-8409-3d83b574f7e5"), 2, false, new Guid("55a650b4-aede-4e66-b74e-0765b1d55847"), new Guid("d6abb460-4201-4d4f-8fe0-ecaed255f35c") },
                    { new Guid("0645a8d4-083e-40f0-b43a-90f5a63e5559"), 3, false, new Guid("55a650b4-aede-4e66-b74e-0765b1d55847"), new Guid("51a11976-7e6d-48c6-bd0a-54e3787d43bf") },
                    { new Guid("e2a4d9b6-e649-4e33-ae65-47122c9fccf8"), 4, false, new Guid("55a650b4-aede-4e66-b74e-0765b1d55847"), new Guid("f2e1c5ba-2fd7-438d-941a-4b306098b32d") },
                    { new Guid("5977ac25-fd2c-4a88-9b56-658af982ef41"), 0, true, new Guid("ce66fa6d-8554-4f0e-8219-77de48985bfc"), new Guid("f4b2b8fa-6317-4bb6-8810-4808a5fb1bc5") },
                    { new Guid("564e5d77-eeb4-4f33-a17b-602772b81cbc"), 1, false, new Guid("ce66fa6d-8554-4f0e-8219-77de48985bfc"), new Guid("49c623cb-29e5-4f7e-bf8d-962db0fa14bc") },
                    { new Guid("70bae2ac-d6b5-40a4-b2b1-07f3884c4c96"), 3, false, new Guid("ce66fa6d-8554-4f0e-8219-77de48985bfc"), new Guid("c5db1648-1e0c-48d5-bed1-c7e68256a627") }
                });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[] { new Guid("701e3613-4eb5-4fb0-8f7b-64981745eab8"), new Guid("2be94c11-3696-4756-87f1-defaa33b40a4"), new DateTime(2021, 8, 24, 19, 19, 43, 458, DateTimeKind.Local).AddTicks(1161), new Guid("f4ee07b8-71a5-404d-b796-62b47eb83fa2"), null, new DateTime(2021, 8, 24, 19, 19, 43, 458, DateTimeKind.Local).AddTicks(1162), new Guid("2fd5f106-fc04-492a-b052-f5ab05feb480") });

            migrationBuilder.InsertData(
                table: "question_answers",
                columns: new[] { "id", "chosen_alternative_id", "created_date", "question_id", "removed_date", "updated_date", "user_id" },
                values: new object[,]
                {
                    { new Guid("4c54ec65-50ab-4034-990c-3264da070cd0"), new Guid("38f1adb5-2c77-4790-bdf1-d0167e3763cc"), new DateTime(2021, 8, 24, 19, 19, 43, 457, DateTimeKind.Local).AddTicks(9646), new Guid("655d9837-8c96-4637-aba1-3bd950b9538d"), null, new DateTime(2021, 8, 24, 19, 19, 43, 457, DateTimeKind.Local).AddTicks(9670), new Guid("2fd5f106-fc04-492a-b052-f5ab05feb480") },
                    { new Guid("38beff73-7120-4919-98b8-c005d6e4d55a"), new Guid("afd076a9-1259-4e79-8f10-c5235e8abe28"), new DateTime(2021, 8, 24, 19, 19, 43, 458, DateTimeKind.Local).AddTicks(1146), new Guid("f3b19f35-b868-4993-b6af-c6b8c3eec55e"), null, new DateTime(2021, 8, 24, 19, 19, 43, 458, DateTimeKind.Local).AddTicks(1147), new Guid("2fd5f106-fc04-492a-b052-f5ab05feb480") },
                    { new Guid("aa5eab55-643f-446a-92fb-074cd1e5a9c9"), new Guid("58f8db34-df67-42d5-ad17-9f9f744537b2"), new DateTime(2021, 8, 24, 19, 19, 43, 458, DateTimeKind.Local).AddTicks(1132), new Guid("66755edb-dc2e-4204-99eb-abd34c0bbae0"), null, new DateTime(2021, 8, 24, 19, 19, 43, 458, DateTimeKind.Local).AddTicks(1140), new Guid("2fd5f106-fc04-492a-b052-f5ab05feb480") },
                    { new Guid("a098cac3-6c68-4be9-8a94-76fe1ad31fc2"), new Guid("ac66f2fe-ffa9-4a58-8438-9513048ad321"), new DateTime(2021, 8, 24, 19, 19, 43, 458, DateTimeKind.Local).AddTicks(1150), new Guid("ac8e2eda-a856-48d5-a824-61cc951d3e86"), null, new DateTime(2021, 8, 24, 19, 19, 43, 458, DateTimeKind.Local).AddTicks(1151), new Guid("2fd5f106-fc04-492a-b052-f5ab05feb480") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_exam_child_exam_module_id",
                table: "exam",
                column: "child_exam_module_id");

            migrationBuilder.CreateIndex(
                name: "ix_exam_father_exam_module_id",
                table: "exam",
                column: "father_exam_module_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_exam_exam_child_exam_module_id",
                table: "exam",
                column: "child_exam_module_id",
                principalTable: "exam",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
