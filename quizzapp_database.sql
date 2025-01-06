--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

-- Started on 2025-01-03 18:13:43

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 220 (class 1259 OID 16445)
-- Name: categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.categories (
    id integer NOT NULL,
    name character varying(50) NOT NULL
);


ALTER TABLE public.categories OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16444)
-- Name: categories_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.categories_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.categories_id_seq OWNER TO postgres;

--
-- TOC entry 4831 (class 0 OID 0)
-- Dependencies: 219
-- Name: categories_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.categories_id_seq OWNED BY public.categories.id;


--
-- TOC entry 222 (class 1259 OID 16452)
-- Name: questions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.questions (
    id integer NOT NULL,
    category_id integer,
    question text NOT NULL,
    option_a text NOT NULL,
    option_b text NOT NULL,
    option_c text NOT NULL,
    option_d text NOT NULL,
    correct_option character(1) NOT NULL
);


ALTER TABLE public.questions OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16451)
-- Name: questions_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.questions_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.questions_id_seq OWNER TO postgres;

--
-- TOC entry 4832 (class 0 OID 0)
-- Dependencies: 221
-- Name: questions_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.questions_id_seq OWNED BY public.questions.id;


--
-- TOC entry 224 (class 1259 OID 16466)
-- Name: scores; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.scores (
    id integer NOT NULL,
    user_id integer,
    score integer NOT NULL
);


ALTER TABLE public.scores OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16465)
-- Name: scores_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.scores_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.scores_id_seq OWNER TO postgres;

--
-- TOC entry 4833 (class 0 OID 0)
-- Dependencies: 223
-- Name: scores_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.scores_id_seq OWNED BY public.scores.id;


--
-- TOC entry 218 (class 1259 OID 16435)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id integer NOT NULL,
    username character varying(50) NOT NULL,
    best_score integer DEFAULT 0
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16434)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_id_seq OWNER TO postgres;

--
-- TOC entry 4834 (class 0 OID 0)
-- Dependencies: 217
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- TOC entry 4658 (class 2604 OID 16448)
-- Name: categories id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories ALTER COLUMN id SET DEFAULT nextval('public.categories_id_seq'::regclass);


--
-- TOC entry 4659 (class 2604 OID 16455)
-- Name: questions id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.questions ALTER COLUMN id SET DEFAULT nextval('public.questions_id_seq'::regclass);


--
-- TOC entry 4660 (class 2604 OID 16469)
-- Name: scores id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scores ALTER COLUMN id SET DEFAULT nextval('public.scores_id_seq'::regclass);


--
-- TOC entry 4656 (class 2604 OID 16438)
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- TOC entry 4821 (class 0 OID 16445)
-- Dependencies: 220
-- Data for Name: categories; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.categories VALUES (1, 'General Knowledge');
INSERT INTO public.categories VALUES (2, 'Science');
INSERT INTO public.categories VALUES (3, 'Math');
INSERT INTO public.categories VALUES (4, 'History');


--
-- TOC entry 4823 (class 0 OID 16452)
-- Dependencies: 222
-- Data for Name: questions; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.questions VALUES (9, 1, 'What is the capital of France?', 'Paris', 'London', 'Berlin', 'Madrid', 'A');
INSERT INTO public.questions VALUES (10, 1, 'Who wrote "Hamlet"?', 'Shakespeare', 'Dickens', 'Hemingway', 'Tolkien', 'A');
INSERT INTO public.questions VALUES (11, 1, 'What is the boiling point of water?', '100°C', '90°C', '110°C', '80°C', 'A');
INSERT INTO public.questions VALUES (12, 1, 'Who painted the Mona Lisa?', 'Van Gogh', 'Picasso', 'Da Vinci', 'Rembrandt', 'C');
INSERT INTO public.questions VALUES (13, 1, 'Which gas do plants absorb from the atmosphere?', 'Oxygen', 'Carbon Dioxide', 'Nitrogen', 'Hydrogen', 'B');
INSERT INTO public.questions VALUES (14, 1, 'What is the smallest continent?', 'Australia', 'Europe', 'Antarctica', 'South America', 'A');
INSERT INTO public.questions VALUES (15, 1, 'Which country is known as the Land of the Rising Sun?', 'China', 'Japan', 'South Korea', 'India', 'B');
INSERT INTO public.questions VALUES (16, 1, 'How many continents are there?', '5', '6', '7', '8', 'C');
INSERT INTO public.questions VALUES (17, 1, 'Who developed the theory of relativity?', 'Newton', 'Einstein', 'Tesla', 'Bohr', 'B');
INSERT INTO public.questions VALUES (18, 1, 'Which planet is closest to the sun?', 'Earth', 'Mars', 'Mercury', 'Venus', 'C');
INSERT INTO public.questions VALUES (19, 2, 'Who discovered penicillin?', 'Newton', 'Edison', 'Fleming', 'Darwin', 'C');
INSERT INTO public.questions VALUES (20, 2, 'What is the chemical symbol for gold?', 'Au', 'Ag', 'Go', 'Gd', 'A');
INSERT INTO public.questions VALUES (21, 2, 'What is the hardest natural substance on Earth?', 'Iron', 'Diamond', 'Gold', 'Quartz', 'B');
INSERT INTO public.questions VALUES (22, 2, 'What is the speed of light?', '300,000 km/s', '150,000 km/s', '450,000 km/s', '200,000 km/s', 'A');
INSERT INTO public.questions VALUES (23, 2, 'What is H2O commonly known as?', 'Oxygen', 'Water', 'Hydrogen', 'Salt', 'B');
INSERT INTO public.questions VALUES (24, 2, 'Who proposed the laws of motion?', 'Einstein', 'Newton', 'Galileo', 'Kepler', 'B');
INSERT INTO public.questions VALUES (25, 2, 'Which planet is known as the Red Planet?', 'Venus', 'Mars', 'Jupiter', 'Mercury', 'B');
INSERT INTO public.questions VALUES (26, 2, 'What is the powerhouse of the cell?', 'Ribosome', 'Mitochondria', 'Nucleus', 'Chloroplast', 'B');
INSERT INTO public.questions VALUES (27, 2, 'What gas do humans exhale?', 'Oxygen', 'Carbon Dioxide', 'Nitrogen', 'Hydrogen', 'B');
INSERT INTO public.questions VALUES (28, 2, 'What is the chemical formula for table salt?', 'NaCl', 'KCl', 'NaO', 'CaCl', 'A');
INSERT INTO public.questions VALUES (29, 3, 'What is 5 + 7?', '10', '11', '12', '13', 'C');
INSERT INTO public.questions VALUES (30, 3, 'What is the square root of 64?', '6', '7', '8', '9', 'C');
INSERT INTO public.questions VALUES (31, 3, 'Solve: 9 x 9', '80', '81', '90', '91', 'B');
INSERT INTO public.questions VALUES (32, 3, 'What is the value of pi (approx)?', '3.12', '3.14', '3.16', '3.18', 'B');
INSERT INTO public.questions VALUES (33, 3, 'Which is the first prime number?', '1', '2', '3', '5', 'B');
INSERT INTO public.questions VALUES (34, 3, 'What is 15 divided by 3?', '3', '5', '6', '7', 'B');
INSERT INTO public.questions VALUES (35, 3, 'How many sides does a hexagon have?', '5', '6', '7', '8', 'B');
INSERT INTO public.questions VALUES (36, 3, 'What is 25% of 200?', '25', '50', '75', '100', 'B');
INSERT INTO public.questions VALUES (37, 3, 'What is the cube of 3?', '9', '27', '36', '81', 'B');
INSERT INTO public.questions VALUES (38, 3, 'What is the sum of angles in a triangle?', '90°', '120°', '180°', '360°', 'C');
INSERT INTO public.questions VALUES (39, 4, 'What year did World War II end?', '1944', '1945', '1946', '1947', 'B');
INSERT INTO public.questions VALUES (40, 4, 'Who was the first President of the United States?', 'Jefferson', 'Lincoln', 'Washington', 'Adams', 'C');
INSERT INTO public.questions VALUES (41, 4, 'Where was Napoleon Bonaparte born?', 'France', 'Corsica', 'Italy', 'Spain', 'B');
INSERT INTO public.questions VALUES (42, 4, 'What was the name of the ship on which the Pilgrims traveled to America?', 'Santa Maria', 'Mayflower', 'Endeavour', 'Victoria', 'B');
INSERT INTO public.questions VALUES (43, 4, 'Who was the British Prime Minister during WWII?', 'Churchill', 'Chamberlain', 'Eden', 'Macmillan', 'A');
INSERT INTO public.questions VALUES (44, 4, 'What ancient civilization built the pyramids?', 'Romans', 'Greeks', 'Egyptians', 'Persians', 'C');
INSERT INTO public.questions VALUES (45, 4, 'Who was assassinated on November 22, 1963?', 'Lincoln', 'Kennedy', 'Garfield', 'McKinley', 'B');
INSERT INTO public.questions VALUES (46, 4, 'What city was the Titanic built in?', 'Belfast', 'Liverpool', 'Southampton', 'Glasgow', 'A');
INSERT INTO public.questions VALUES (47, 4, 'Who was known as the Iron Lady?', 'Margaret Thatcher', 'Indira Gandhi', 'Queen Elizabeth', 'Golda Meir', 'A');
INSERT INTO public.questions VALUES (48, 4, 'Who discovered America?', 'Magellan', 'Columbus', 'Vespucci', 'Cabot', 'B');


--
-- TOC entry 4825 (class 0 OID 16466)
-- Dependencies: 224
-- Data for Name: scores; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4819 (class 0 OID 16435)
-- Dependencies: 218
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.users VALUES (1, 'zanakadir', 2);
INSERT INTO public.users VALUES (2, 'kadir', 4);


--
-- TOC entry 4835 (class 0 OID 0)
-- Dependencies: 219
-- Name: categories_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.categories_id_seq', 4, true);


--
-- TOC entry 4836 (class 0 OID 0)
-- Dependencies: 221
-- Name: questions_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.questions_id_seq', 48, true);


--
-- TOC entry 4837 (class 0 OID 0)
-- Dependencies: 223
-- Name: scores_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.scores_id_seq', 1, false);


--
-- TOC entry 4838 (class 0 OID 0)
-- Dependencies: 217
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 2, true);


--
-- TOC entry 4666 (class 2606 OID 16450)
-- Name: categories categories_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categories
    ADD CONSTRAINT categories_pkey PRIMARY KEY (id);


--
-- TOC entry 4668 (class 2606 OID 16459)
-- Name: questions questions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.questions
    ADD CONSTRAINT questions_pkey PRIMARY KEY (id);


--
-- TOC entry 4670 (class 2606 OID 16471)
-- Name: scores scores_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scores
    ADD CONSTRAINT scores_pkey PRIMARY KEY (id);


--
-- TOC entry 4662 (class 2606 OID 16441)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- TOC entry 4664 (class 2606 OID 16443)
-- Name: users users_username_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_username_key UNIQUE (username);


--
-- TOC entry 4671 (class 2606 OID 16460)
-- Name: questions questions_category_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.questions
    ADD CONSTRAINT questions_category_id_fkey FOREIGN KEY (category_id) REFERENCES public.categories(id);


--
-- TOC entry 4672 (class 2606 OID 16472)
-- Name: scores scores_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scores
    ADD CONSTRAINT scores_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(id);


-- Completed on 2025-01-03 18:13:44

--
-- PostgreSQL database dump complete
--

