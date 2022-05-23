--
-- PostgreSQL database dump
--

-- Dumped from database version 14.3
-- Dumped by pg_dump version 14.3

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: uuid-ossp; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS "uuid-ossp" WITH SCHEMA public;


--
-- Name: EXTENSION "uuid-ossp"; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION "uuid-ossp" IS 'generate universally unique identifiers (UUIDs)';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: department; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.department (
    id uuid NOT NULL,
    headmaster_id uuid NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.department OWNER TO postgres;

--
-- Name: group; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."group" (
    id uuid NOT NULL,
    department_id uuid NOT NULL,
    short_name text NOT NULL,
    course integer NOT NULL,
    education_type text NOT NULL,
    educational_program text NOT NULL,
    form_of_education text NOT NULL,
    speciality_code text NOT NULL,
    speciality_name text NOT NULL,
    year_of_issue integer NOT NULL
);


ALTER TABLE public."group" OWNER TO postgres;

--
-- Name: group_student; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.group_student (
    group_id uuid NOT NULL,
    student_id uuid NOT NULL
);


ALTER TABLE public.group_student OWNER TO postgres;

--
-- Name: person; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.person (
    id uuid NOT NULL,
    first_name text NOT NULL,
    last_name text NOT NULL,
    patronymic text
);


ALTER TABLE public.person OWNER TO postgres;

--
-- Name: student; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.student (
    id uuid NOT NULL,
    person_id uuid NOT NULL,
    teacher_id uuid NOT NULL,
    topic_of_final_qualification_work text,
    basis_of_education text
);


ALTER TABLE public.student OWNER TO postgres;

--
-- Name: teacher; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.teacher (
    id uuid NOT NULL,
    person_id uuid NOT NULL,
    science_degree text,
    job_vacancy text
);


ALTER TABLE public.teacher OWNER TO postgres;

--
-- Data for Name: department; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.department (id, headmaster_id, name) FROM stdin;
e61b79da-b76a-4dd3-85ff-10775be99b13	595653c7-e852-4955-a9f7-45cda983e1a9	Математического анализа и теории функции
\.


--
-- Data for Name: group; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."group" (id, department_id, short_name, course, education_type, educational_program, form_of_education, speciality_code, speciality_name, year_of_issue) FROM stdin;
29250c06-59cd-4243-b361-ba1e743b26c1	e61b79da-b76a-4dd3-85ff-10775be99b13	МКНб-181	4	бакалавриат	Математический анализ и компьютерные науки	очная	02.03.01	Математика и компьютерные науки	2021
4ba38c8f-8925-4b39-a8bd-df4b829f2053	e61b79da-b76a-4dd3-85ff-10775be99b13	ПИб-181	4	бакалавриат	Информационное обеспечение автоматизированных систем	очная	09.03.03	Прикладная информатика	2021
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	e61b79da-b76a-4dd3-85ff-10775be99b13	Мм-201	2	магистратура	Вычислительная математика и информатика	очная	01.04.01	Математика	2021
7751d49c-f205-4632-b6c3-f9a8a2033e60	e61b79da-b76a-4dd3-85ff-10775be99b13	ПИМм-201	2	магистратура	Информационное обеспечение автоматизированных систем	очная	09.04.03	Прикладная информатика	2021
\.


--
-- Data for Name: group_student; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.group_student (group_id, student_id) FROM stdin;
29250c06-59cd-4243-b361-ba1e743b26c1	0e8fd596-ee07-4527-9e4e-204ff29ec05a
29250c06-59cd-4243-b361-ba1e743b26c1	3fefc519-edf0-47fa-9aaa-9f90b647a9d6
29250c06-59cd-4243-b361-ba1e743b26c1	6887b048-fe85-47d8-9464-fc1fe74916d8
29250c06-59cd-4243-b361-ba1e743b26c1	00ab1f32-1371-4c87-ac93-80980edbef01
29250c06-59cd-4243-b361-ba1e743b26c1	0c838e24-5ba0-4e5e-8914-7147fa9b31b7
29250c06-59cd-4243-b361-ba1e743b26c1	56109366-6844-4b74-aa5c-eb5ddd0ee6f1
29250c06-59cd-4243-b361-ba1e743b26c1	7e9e7cbb-6635-4837-ae7f-cfdd9e9afeb0
29250c06-59cd-4243-b361-ba1e743b26c1	773554d6-e5be-4620-9c73-8c056a73e1fd
29250c06-59cd-4243-b361-ba1e743b26c1	324be59c-8312-47bf-a017-63faf06034fb
29250c06-59cd-4243-b361-ba1e743b26c1	bb1e1131-ae99-4d7d-b366-861fdda47452
29250c06-59cd-4243-b361-ba1e743b26c1	3f0dc8f3-562a-4c79-b8ac-c190e1914316
29250c06-59cd-4243-b361-ba1e743b26c1	d53df3c4-235c-451c-8067-1ba717e08467
29250c06-59cd-4243-b361-ba1e743b26c1	4b750eb0-9065-40ac-98af-c7cacb230566
29250c06-59cd-4243-b361-ba1e743b26c1	b235902a-1310-4b9f-b6b1-346649d504fa
29250c06-59cd-4243-b361-ba1e743b26c1	1aea1a43-9796-4114-b3fe-3625b9c3f23a
29250c06-59cd-4243-b361-ba1e743b26c1	cbe29340-78d5-4488-bdaa-70f58a02dfbf
29250c06-59cd-4243-b361-ba1e743b26c1	e375d11f-4c24-47c2-9451-31c301072ea7
29250c06-59cd-4243-b361-ba1e743b26c1	36313157-9c24-4fbf-a83d-f7a54c4362d8
29250c06-59cd-4243-b361-ba1e743b26c1	59907b8b-aef0-439f-8132-848aa67a8c76
29250c06-59cd-4243-b361-ba1e743b26c1	c0327043-0e9d-4511-b46c-9bcd419100ff
29250c06-59cd-4243-b361-ba1e743b26c1	14b1d509-0175-43ff-97d1-8a11c126241c
29250c06-59cd-4243-b361-ba1e743b26c1	328f4912-cd9e-4bb5-aca7-57191a215bc1
4ba38c8f-8925-4b39-a8bd-df4b829f2053	a81ef0af-b4b6-44be-b885-c2384a47e8e2
4ba38c8f-8925-4b39-a8bd-df4b829f2053	043d34b5-6f44-4b98-9ed9-63bc1f97c536
4ba38c8f-8925-4b39-a8bd-df4b829f2053	3099a863-0c2f-4006-8d26-566c660ef1e6
4ba38c8f-8925-4b39-a8bd-df4b829f2053	5bb2f7d9-c058-4dc2-ae7b-f3481fef0373
4ba38c8f-8925-4b39-a8bd-df4b829f2053	311c8768-bc02-47ac-bd6b-24d43d8ac0ca
4ba38c8f-8925-4b39-a8bd-df4b829f2053	115cea44-d769-4138-851f-a65567f751dc
4ba38c8f-8925-4b39-a8bd-df4b829f2053	1c4b7e5f-c738-4643-b268-26f5847222c2
4ba38c8f-8925-4b39-a8bd-df4b829f2053	7cee722e-699d-4a20-b97d-c880accd3bed
4ba38c8f-8925-4b39-a8bd-df4b829f2053	bef4ed1f-51b4-44f9-af00-f3eb0513cf75
4ba38c8f-8925-4b39-a8bd-df4b829f2053	1427f9c3-9110-4950-8f3c-ef9b45815440
4ba38c8f-8925-4b39-a8bd-df4b829f2053	2109c427-9457-4ed5-ab79-50608e979b29
4ba38c8f-8925-4b39-a8bd-df4b829f2053	4a15348f-ec32-4611-a73d-af9923432328
4ba38c8f-8925-4b39-a8bd-df4b829f2053	ad82d670-a063-4579-b84b-8249dee818d8
4ba38c8f-8925-4b39-a8bd-df4b829f2053	42c40c63-e114-4b5e-9665-3f8bebb9a77d
4ba38c8f-8925-4b39-a8bd-df4b829f2053	74f63800-260e-49e9-9c23-cd2b16677019
7751d49c-f205-4632-b6c3-f9a8a2033e60	d6602e17-c86d-402c-bd46-e99b8bdbd60b
7751d49c-f205-4632-b6c3-f9a8a2033e60	106ddf39-5510-445a-8a9e-f27343617fba
7751d49c-f205-4632-b6c3-f9a8a2033e60	53eba1c2-7beb-4ab6-89ea-57779a0f83bf
7751d49c-f205-4632-b6c3-f9a8a2033e60	2fce86b1-670c-499e-a1ce-0f35ba365fc0
7751d49c-f205-4632-b6c3-f9a8a2033e60	15000745-6074-4e14-97be-ce9348fe6f81
7751d49c-f205-4632-b6c3-f9a8a2033e60	05ba943f-4065-4305-a49c-3b328d2648d6
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	4fa6123e-2aa3-4bed-9597-42e9f6f268f9
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	51aff5f4-3f56-4b30-a0d9-5f00567ed01a
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	4af6d427-07ad-4d12-8564-ac7b7bc941be
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	169ce09b-982a-4315-8aa9-78dc968955f0
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	b997ef3c-97be-4d1a-b6af-6ed19fe81360
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	919bef6a-75da-44e8-aeef-3562b7573949
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	4eeb6207-aa47-4a10-acf1-2be74ea1c17a
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	c014950f-2360-48e3-a80c-09342f583b79
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	61057223-46e7-4b4e-8d0a-614c4cd10726
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	27f402c3-f9f3-43d4-9f9d-c64a42a89d6c
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	38469975-b8a0-4d5c-bd0d-ec63335d25b2
ebd5c9d2-8a8a-4627-ba29-4e98eb7f3b77	531320d0-b96e-4b22-a507-e5805ce800d8
\.


--
-- Data for Name: person; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.person (id, first_name, last_name, patronymic) FROM stdin;
cb5172e1-3e78-4ae2-9884-9d13c8e519d4	Клячин	Алексей	Александрович
4eef75ff-848c-4184-ae7c-b257865821d5	Гермашев	Илья	Васильевич
33dc8df1-750f-4f0a-81ca-af72f6285d3d	Лосев	Александр	Георгиевич
18eef2a9-3fb4-4e97-a1c0-7129aabb6006	Бондарева	Елена	Владимировна
d784c128-571b-444e-88d1-8c50e12e05fa	Жданович	Павел	Борисович
856ce89c-f7f7-442a-a677-c43575c9a424	Мазепа	Елена	Алексеевна
d54a5294-e6ed-4bdd-90d0-f1ab1b469b4d	Машихина	Татьяна	Петровна
7831c52b-c67e-45a9-a966-691faffc4a2d	Романова	Ирина	Андреевна
037de22e-3813-4649-9a14-72c38ac12082	Светлов	Андрей	Владимирович
c599eb51-f4f0-472a-a73a-187a545763a2	Корольков	Сергей	Алексеевич
7ac761fa-8c47-49b4-bf11-ccc9868fe47c	Касьянов	Сергей	Николаевич
a09d5bf5-3570-4833-928f-1caf228ada5e	Айвазян	Валентина	Айказовна
80dcb946-fd07-490d-8526-6bffdbd735b8	Балахонов	Александр	Андреевич
b7f40d45-7582-49c5-89b0-7bd92fb2d0be	Булыгин	Алексей	Сергеевич
e1185b7e-fe6d-448e-9703-596f4d9292af	Волкова	Ирина	Сергеевна
c491ba35-0eed-4b9c-9e91-f01bbd5689c3	Горшков	Иван	Андреевич
ad9e074f-398b-48f7-ba60-b7c71a4762d5	Даниленко	Людмила	Алексеевна
9d50b55a-ea0f-4439-8bd0-72d5c908f11f	Димитрова	Екатерина	Анатольевна
24992cca-9324-4a67-abd4-33731ac26c54	Евдокимов	Петр	Дмитриевич
79bf4543-f872-40ad-a60b-332e37be009a	Жарова	Полина	Владимировна
60c215b7-5e5c-496a-a565-707e842f6190	Зорькин	Дмитрий	Юрьевич
4927b44d-ff13-4994-87b9-6093cd07e19c	Зуева	Екатерина	Владимировна
b25ee683-123d-4912-b50c-fbf900881939	Комарова	Ольга	Геннадьевна
0416f9e9-4b07-498e-bb12-99a3d3cb61a8	Кретова	Дарья	Дмитриевна
55b1b238-3f4f-4b0e-ad7c-9c418e4f7a7c	Маклецов	Максим	Сергеевич
dd025d87-39e2-4cfe-8978-4c152208cdf7	Мартыневский	Даниил	Андреевич
10b864ab-fca4-483d-a111-dcde20af87b4	Мащалкин	Никита	Дмитриевич
0a601d3b-881b-4662-825c-3f914c125800	Смолина	Дарья	Васильевна
6b8404ac-f882-46db-9171-1b0d0f54c103	Суворов	Аркадий	Александрович
ba994e45-f634-494a-8526-1257d0ea05a5	Топазова	Олеся	Вячеславовна
d63aa31a-c27c-46ea-9978-199a89faf8cb	Третьяков	Максим	Андреевич
3ed2dc0e-3193-43bd-be82-aee16078e97e	Хайрулин	Евгений	Михайлович
97e82328-1dbd-4da2-a5c6-ede8baf01077	Чекомасов	Дмитрий	Сергеевич
c4a4d5eb-bc28-4858-ac85-81c04ec9378a	Артемова	Мария	Евгеньевна
b202a2a9-1c07-43a1-8047-c4aa2b272345	Брыжина	Кристина	Александровна
b3941405-1306-4b38-804c-3f6e0ce2fb78	Габдерахманов	Вадим	Миннурович
ce8eedb9-00a4-4fc9-ad4f-df27890daf6c	Гордеева	Анастасия	Дмитриевна
df5338f3-8aad-4d32-a1db-8bfaf91ecd17	Долбенко	Максим	Сергеевич
4f52ad32-cf37-4aee-ba13-132c70c812da	Ерошенко	Александр	Ильич
d7d1dd8a-b9e4-448d-82ec-0a2ab80c291e	Зайцев	Александр	Владимирович
35e73c45-5340-46e1-9723-d8590cf16c4f	Калуга	Арина	Павловна
de953481-c68a-40c4-9177-bf21ca809f98	Канделаки	Данил	Эмзарович
c5ae74be-adef-4083-b4a4-9b34bfe0a695	Кузьмин	Алексей	Витальевич
07c31b16-7233-4c87-b4cb-3bbe7fdee372	Матвеева	Наталья	Алексеевна
d3f4193e-a8d0-467f-9859-376704bba190	Сайгин	Павел	Алексеевич
c5488b02-ff4e-43dd-bfdb-3d478b2f7379	Тарасенко	Ирина	Олеговна
0bd32d29-e0a3-428f-98a4-f1d9b50a0035	Укустов	Максим	Дмитриевич
d4132efb-b97b-417d-a60f-5d90248450b0	Щурин	Денис	Олегович
e8aa8915-02d3-4dde-a6aa-f9616aa60951	Бадмаев	Алексей	Дмитриевич
73362ac0-9c29-415a-acd4-b46b3a0821b1	Зия	Зияуддин	\N
edf86430-c4db-48a4-9a67-6a52977b9244	Киреева	Екатерина	Сергеевна
396af9ea-63c0-4941-8557-f9de6197b9e3	Короткова	Мария	Александровна
e588ac27-4408-4d23-8acf-a55cbe947e64	Протопопов	Игорь	Владимирович
328aab43-a635-4485-9d2a-88924f44a4b8	Резниченко	Юлия	Николаевна
746d67e6-c9dc-40e7-81b8-feb3987bcc5a	Салих Мохаммед	Мохсин	Салих
ebf2f4dc-1d90-43f0-bc87-8769517b3764	Синцов	Павел	Андреевич
dda428d5-949a-446d-af72-ddf1db47d365	Чайкин	Виктор	Александрович
15addd40-6925-4e01-a773-4c662c810b7b	Чуйко	Илья	Иванович
9f3d6ddc-ad89-4e6e-81ab-8944ac47c19d	Шайагзамова	Комила	Олимовна
8796bd0f-55a2-42ae-8097-fcea948a039a	Шаманин	Владимир	Вячеславович
a5580720-5c09-4352-9066-3ae2b1c9af14	Гуль	Нассибулла	Касем
4f089306-098c-432d-991d-105bf3b02c30	Данилов	Дмитрий	Валерьевич
b097cab0-1ab8-4551-b3cd-7f0e6633a255	Ермолаев	Александр	Александрович
3cbdc938-2d17-4898-a513-516d6c01ccbb	Павлов	Артур	Валерьевич
68017130-fec1-4b10-87b5-b4701c378846	Сапич	Юлия	Дмитриевна
37ce0a3e-e247-4b10-ab76-9e4891a64aa8	Скляренко	Александр	Романович
8146c82d-40bf-4cea-9c93-f38d66de13de	Шаманин	Владимир	Вячеславович
\.


--
-- Data for Name: student; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.student (id, person_id, teacher_id, topic_of_final_qualification_work, basis_of_education) FROM stdin;
4b750eb0-9065-40ac-98af-c7cacb230566	0416f9e9-4b07-498e-bb12-99a3d3cb61a8	595653c7-e852-4955-a9f7-45cda983e1a9	Проектирование специализированного сайта вакансий	договор
2109c427-9457-4ed5-ab79-50608e979b29	07c31b16-7233-4c87-b4cb-3bbe7fdee372	9d35894c-6bcc-4d6f-abc0-4cf8cc7dd014	Разработка информационной системы для салона маникюра	бюджет
e375d11f-4c24-47c2-9451-31c301072ea7	0a601d3b-881b-4662-825c-3f914c125800	595653c7-e852-4955-a9f7-45cda983e1a9	Триангуляция методом измельчения плоской области, заданной графически	бюджет
42c40c63-e114-4b5e-9665-3f8bebb9a77d	0bd32d29-e0a3-428f-98a4-f1d9b50a0035	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	Разработка информационной системы периодического издания	бюджет
cbe29340-78d5-4488-bdaa-70f58a02dfbf	10b864ab-fca4-483d-a111-dcde20af87b4	9d35894c-6bcc-4d6f-abc0-4cf8cc7dd014	Создание мобильного приложения в среде разработки unity с использованием 3D (командный проект)	бюджет
27f402c3-f9f3-43d4-9f9d-c64a42a89d6c	15addd40-6925-4e01-a773-4c662c810b7b	9d35894c-6bcc-4d6f-abc0-4cf8cc7dd014	Разработка интернет-портала ГБУ СО «Кировский ЦСОН»	бюджет
773554d6-e5be-4620-9c73-8c056a73e1fd	24992cca-9324-4a67-abd4-33731ac26c54	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	3D моделирование проектов восстановления Сталинграда после Великой Отечественной войны	бюджет
919bef6a-75da-44e8-aeef-3562b7573949	328aab43-a635-4485-9d2a-88924f44a4b8	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	Разработка информационной системы автоматизации документооборота при учете НИР и ВКР выпускающей кафедры	бюджет
7cee722e-699d-4a20-b97d-c880accd3bed	35e73c45-5340-46e1-9723-d8590cf16c4f	9a30a919-d1ed-4afe-9f0a-4f3268e388bb	Регрессионный анализ термометрических данных пациентов с заболеванием молочных желез	бюджет
05ba943f-4065-4305-a49c-3b328d2648d6	37ce0a3e-e247-4b10-ab76-9e4891a64aa8	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	Разработка информационной системы поддержки административно-финансовой деятельности веб-студии	бюджет
169ce09b-982a-4315-8aa9-78dc968955f0	396af9ea-63c0-4941-8557-f9de6197b9e3	9d35894c-6bcc-4d6f-abc0-4cf8cc7dd014	Программа по автоматизации приема нефти на переработку различными видами транспорта	договор
2fce86b1-670c-499e-a1ce-0f35ba365fc0	3cbdc938-2d17-4898-a513-516d6c01ccbb	9d35894c-6bcc-4d6f-abc0-4cf8cc7dd014	Создание приложения для лингвистического корпуса документов XVIII – XIX вв. канцелярий Войска Донского (групповой проект)	бюджет
14b1d509-0175-43ff-97d1-8a11c126241c	3ed2dc0e-3193-43bd-be82-aee16078e97e	595653c7-e852-4955-a9f7-45cda983e1a9	Обобщенные решения задачи Дирихле на модельных римановых многообразиях	бюджет
3f0dc8f3-562a-4c79-b8ac-c190e1914316	4927b44d-ff13-4994-87b9-6093cd07e19c	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	Виртуальная реконструкция монументальных культовых сооружений Золотой Орды: анализ сходства с сельджукскими образцами.	договор
106ddf39-5510-445a-8a9e-f27343617fba	4f089306-098c-432d-991d-105bf3b02c30	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	Информационная система автоматизации аналитики SMM	бюджет
115cea44-d769-4138-851f-a65567f751dc	4f52ad32-cf37-4aee-ba13-132c70c812da	595653c7-e852-4955-a9f7-45cda983e1a9	Применение 3D моделирования в маркетинге	бюджет
b235902a-1310-4b9f-b6b1-346649d504fa	55b1b238-3f4f-4b0e-ad7c-9c418e4f7a7c	595653c7-e852-4955-a9f7-45cda983e1a9	Разработка мобильного приложения для взаимной работы учителя математики с учениками	бюджет
bb1e1131-ae99-4d7d-b366-861fdda47452	60c215b7-5e5c-496a-a565-707e842f6190	595653c7-e852-4955-a9f7-45cda983e1a9	Автоматизация процесса формирования личной электронной библиотеки	бюджет
15000745-6074-4e14-97be-ce9348fe6f81	68017130-fec1-4b10-87b5-b4701c378846	9d35894c-6bcc-4d6f-abc0-4cf8cc7dd014	Создание приложения для лингвистического корпуса документов XVIII – XIX вв. канцелярий Войска Донского (групповой проект)	бюджет
36313157-9c24-4fbf-a83d-f7a54c4362d8	6b8404ac-f882-46db-9171-1b0d0f54c103	595653c7-e852-4955-a9f7-45cda983e1a9	Разработка виртуальной экскурсии на примере замка Бран	бюджет
51aff5f4-3f56-4b30-a0d9-5f00567ed01a	73362ac0-9c29-415a-acd4-b46b3a0821b1	595653c7-e852-4955-a9f7-45cda983e1a9	Оценка геометрической характеристики триангуляции плоской области, связанной с погрешностью вычислений	целевой прием
4eeb6207-aa47-4a10-acf1-2be74ea1c17a	746d67e6-c9dc-40e7-81b8-feb3987bcc5a	595653c7-e852-4955-a9f7-45cda983e1a9	Оптимизация формы триангуляции многоугольной области	договор
324be59c-8312-47bf-a017-63faf06034fb	79bf4543-f872-40ad-a60b-332e37be009a	595653c7-e852-4955-a9f7-45cda983e1a9	Разработка мобильного приложения для управления личными финансами	бюджет
3fefc519-edf0-47fa-9aaa-9f90b647a9d6	80dcb946-fd07-490d-8526-6bffdbd735b8	595653c7-e852-4955-a9f7-45cda983e1a9	Создание сайта с головоломками, основанными на прохождении лабиринтов на JavaScript	бюджет
328f4912-cd9e-4bb5-aca7-57191a215bc1	97e82328-1dbd-4da2-a5c6-ede8baf01077	2395be8d-22d9-4405-b4a8-5df2594ceee2	Плотные подмножества пространств гармонических функций на модельных римановых многообразиях	договор
7e9e7cbb-6635-4837-ae7f-cfdd9e9afeb0	9d50b55a-ea0f-4439-8bd0-72d5c908f11f	595653c7-e852-4955-a9f7-45cda983e1a9	Разработка мобильного приложения для управления личными финансами	бюджет
38469975-b8a0-4d5c-bd0d-ec63335d25b2	9f3d6ddc-ad89-4e6e-81ab-8944ac47c19d	2395be8d-22d9-4405-b4a8-5df2594ceee2	Геометрия треугольника в школьном образовании	бюджет
0e8fd596-ee07-4527-9e4e-204ff29ec05a	a09d5bf5-3570-4833-928f-1caf228ada5e	9d35894c-6bcc-4d6f-abc0-4cf8cc7dd014	Проектирование информационной системы фотоателье	бюджет
d6602e17-c86d-402c-bd46-e99b8bdbd60b	a5580720-5c09-4352-9066-3ae2b1c9af14	8fb11817-0b4b-45d4-a679-4a01d117db8d	Разработка и интеграция сайта по доставке еды с информационной системой на основе IIKO	бюджет
56109366-6844-4b74-aa5c-eb5ddd0ee6f1	ad9e074f-398b-48f7-ba60-b7c71a4762d5	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	3D моделирование проектов восстановления Сталинграда после Великой Отечественной войны	бюджет
53eba1c2-7beb-4ab6-89ea-57779a0f83bf	b097cab0-1ab8-4551-b3cd-7f0e6633a255	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	Автоматизация финансового планирования cтудии веб-разработки	бюджет
043d34b5-6f44-4b98-9ed9-63bc1f97c536	b202a2a9-1c07-43a1-8047-c4aa2b272345	2395be8d-22d9-4405-b4a8-5df2594ceee2	Факторный анализ данных в задаче диагностики рака молочной железы	бюджет
d53df3c4-235c-451c-8067-1ba717e08467	b25ee683-123d-4912-b50c-fbf900881939	595653c7-e852-4955-a9f7-45cda983e1a9	Триангуляция методом измельчения плоской области, заданной системой неравенств	бюджет
3099a863-0c2f-4006-8d26-566c660ef1e6	b3941405-1306-4b38-804c-3f6e0ce2fb78	9d35894c-6bcc-4d6f-abc0-4cf8cc7dd014	Разработка мобильного приложения для исследования алгоритмов	бюджет
6887b048-fe85-47d8-9464-fc1fe74916d8	b7f40d45-7582-49c5-89b0-7bd92fb2d0be	595653c7-e852-4955-a9f7-45cda983e1a9	Применение статистических характеристик для распознавания изображения текста	договор
59907b8b-aef0-439f-8132-848aa67a8c76	ba994e45-f634-494a-8526-1257d0ea05a5	2395be8d-22d9-4405-b4a8-5df2594ceee2	Обобщенные решения задачи Дирихле на модельных римановых многообразиях	бюджет
0c838e24-5ba0-4e5e-8914-7147fa9b31b7	c491ba35-0eed-4b9c-9e91-f01bbd5689c3	595653c7-e852-4955-a9f7-45cda983e1a9	Создание мобильного приложения в среде разработки unity с использованием 3D (командный проект)	бюджет
a81ef0af-b4b6-44be-b885-c2384a47e8e2	c4a4d5eb-bc28-4858-ac85-81c04ec9378a	9d35894c-6bcc-4d6f-abc0-4cf8cc7dd014	Создание веб-приложения для сравнения услуг каршеринга и такси	бюджет
ad82d670-a063-4579-b84b-8249dee818d8	c5488b02-ff4e-43dd-bfdb-3d478b2f7379	ad455b48-c793-4fc6-aea8-3503810d2554	Управление XML-данными в автоматизированном педагогическом тестировании	бюджет
1427f9c3-9110-4950-8f3c-ef9b45815440	c5ae74be-adef-4083-b4a4-9b34bfe0a695	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	Разработка виртуальной экскурсии по кафедральной мечети Водянского городища	бюджет
5bb2f7d9-c058-4dc2-ae7b-f3481fef0373	ce8eedb9-00a4-4fc9-ad4f-df27890daf6c	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	Проектирование и разработка игрового приложения в среде разработки Unreal Engine	бюджет
4a15348f-ec32-4611-a73d-af9923432328	d3f4193e-a8d0-467f-9859-376704bba190	8fb11817-0b4b-45d4-a679-4a01d117db8d	Идентификация наличия заболеваний Covid-19 и пневмонии по данным микроволновой радиотермометрии	бюджет
74f63800-260e-49e9-9c23-cd2b16677019	d4132efb-b97b-417d-a60f-5d90248450b0	8fb11817-0b4b-45d4-a679-4a01d117db8d	Информационная система обработки данных для машинного обучения	бюджет
c0327043-0e9d-4511-b46c-9bcd419100ff	d63aa31a-c27c-46ea-9978-199a89faf8cb	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	Разработка виртуальной экскурсии по поселениям Золотой Орды: интерьер жилого помещения	бюджет
1c4b7e5f-c738-4643-b268-26f5847222c2	d7d1dd8a-b9e4-448d-82ec-0a2ab80c291e	9d35894c-6bcc-4d6f-abc0-4cf8cc7dd014	Разработка информационной системы кофейни	бюджет
1aea1a43-9796-4114-b3fe-3625b9c3f23a	dd025d87-39e2-4cfe-8978-4c152208cdf7	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	Метод кусочно-полиномиальных функций для решения вариационных задач	бюджет
61057223-46e7-4b4e-8d0a-614c4cd10726	dda428d5-949a-446d-af72-ddf1db47d365	595653c7-e852-4955-a9f7-45cda983e1a9	Метод кусочно-полиномиальных функций для решения вариационных задач	бюджет
bef4ed1f-51b4-44f9-af00-f3eb0513cf75	de953481-c68a-40c4-9177-bf21ca809f98	8fb11817-0b4b-45d4-a679-4a01d117db8d	Информационная система для управления обучающими выборками машинного обучения	бюджет
311c8768-bc02-47ac-bd6b-24d43d8ac0ca	df5338f3-8aad-4d32-a1db-8bfaf91ecd17	2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	Проектирование и разработка игрового приложения: проектирование локаций и система интерактивных взаимодействий	бюджет
00ab1f32-1371-4c87-ac93-80980edbef01	e1185b7e-fe6d-448e-9703-596f4d9292af	9d35894c-6bcc-4d6f-abc0-4cf8cc7dd014	Создание интернет-портала проекта "Мой Ахтубинск"	бюджет
b997ef3c-97be-4d1a-b6af-6ed19fe81360	e588ac27-4408-4d23-8acf-a55cbe947e64	8fb11817-0b4b-45d4-a679-4a01d117db8d	Создание интернет-портала проекта "Мой Ахтубинск"	бюджет
4fa6123e-2aa3-4bed-9597-42e9f6f268f9	e8aa8915-02d3-4dde-a6aa-f9616aa60951	595653c7-e852-4955-a9f7-45cda983e1a9	Числа Пизо и их приложения в задачах сжатия данных	бюджет
c014950f-2360-48e3-a80c-09342f583b79	ebf2f4dc-1d90-43f0-bc87-8769517b3764	595653c7-e852-4955-a9f7-45cda983e1a9	Алгоритмы построения поверхностей с нерегулярной структурой	бюджет
4af6d427-07ad-4d12-8564-ac7b7bc941be	edf86430-c4db-48a4-9a67-6a52977b9244	595653c7-e852-4955-a9f7-45cda983e1a9	Формирование 3D рельефа местности по геодезическим измерениям и фотоснимкам	бюджет
531320d0-b96e-4b22-a507-e5805ce800d8	8146c82d-40bf-4cea-9c93-f38d66de13de	595653c7-e852-4955-a9f7-45cda983e1a9	Применение методов классификации в задачах анализа изображений с помощью Scikit-Learn	бюджет
\.


--
-- Data for Name: teacher; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.teacher (id, person_id, science_degree, job_vacancy) FROM stdin;
9d35894c-6bcc-4d6f-abc0-4cf8cc7dd014	037de22e-3813-4649-9a14-72c38ac12082	к.ф.-м.н.	доцент
5e530b41-7547-40d4-a5d9-382772af6779	18eef2a9-3fb4-4e97-a1c0-7129aabb6006	к.пед.н.	доцент
2395be8d-22d9-4405-b4a8-5df2594ceee2	33dc8df1-750f-4f0a-81ca-af72f6285d3d	д.ф.-м.н.	профессор
8fb11817-0b4b-45d4-a679-4a01d117db8d	4eef75ff-848c-4184-ae7c-b257865821d5	д.ф.-м.н.	профессор
2dd8fbbd-bd2c-408e-9dd2-c4c0e916b868	7831c52b-c67e-45a9-a966-691faffc4a2d	к.ф.-м.н.	доцент
30a01038-9fe6-4f26-9601-a88c0c98f6c9	7ac761fa-8c47-49b4-bf11-ccc9868fe47c	к.ф.-м.н.	доцент
9a30a919-d1ed-4afe-9f0a-4f3268e388bb	856ce89c-f7f7-442a-a677-c43575c9a424	к.ф.-м.н.	доцент
a9630a8c-c6a4-4d8a-8f01-979efce0c2c4	c599eb51-f4f0-472a-a73a-187a545763a2	к.ф.-м.н.	доцент
595653c7-e852-4955-a9f7-45cda983e1a9	cb5172e1-3e78-4ae2-9884-9d13c8e519d4	д.ф.-м.н.	профессор
8825fa45-c6bc-46f1-9602-3f923466bc8b	d54a5294-e6ed-4bdd-90d0-f1ab1b469b4d	к.ф.-м.н.	доцент
ad455b48-c793-4fc6-aea8-3503810d2554	d784c128-571b-444e-88d1-8c50e12e05fa	к.ф.-м.н.	доцент
\.


--
-- Name: department department_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.department
    ADD CONSTRAINT department_pkey PRIMARY KEY (id);


--
-- Name: group group_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."group"
    ADD CONSTRAINT group_pkey PRIMARY KEY (id);


--
-- Name: person person_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.person
    ADD CONSTRAINT person_pkey PRIMARY KEY (id);


--
-- Name: student student_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT student_pkey PRIMARY KEY (id);


--
-- Name: teacher teacher_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT teacher_pkey PRIMARY KEY (id);


--
-- Name: department department_headmaster_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.department
    ADD CONSTRAINT department_headmaster_id_fkey FOREIGN KEY (headmaster_id) REFERENCES public.teacher(id) NOT VALID;


--
-- Name: group group_department_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."group"
    ADD CONSTRAINT group_department_id_fkey FOREIGN KEY (department_id) REFERENCES public.department(id) NOT VALID;


--
-- Name: group_student group_student_group_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.group_student
    ADD CONSTRAINT group_student_group_id_fkey FOREIGN KEY (group_id) REFERENCES public."group"(id) NOT VALID;


--
-- Name: group_student group_student_student_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.group_student
    ADD CONSTRAINT group_student_student_id_fkey FOREIGN KEY (student_id) REFERENCES public.student(id) NOT VALID;


--
-- Name: student student_person_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT student_person_id_fkey FOREIGN KEY (person_id) REFERENCES public.person(id) NOT VALID;


--
-- Name: student student_teacher_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT student_teacher_id_fkey FOREIGN KEY (teacher_id) REFERENCES public.teacher(id) NOT VALID;


--
-- Name: teacher teacher_person_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT teacher_person_id_fkey FOREIGN KEY (person_id) REFERENCES public.person(id) NOT VALID;


--
-- PostgreSQL database dump complete
--

