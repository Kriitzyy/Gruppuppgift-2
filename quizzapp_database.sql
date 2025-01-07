-- Skapande av tabeller
CREATE TABLE public.categories (
    id integer NOT NULL DEFAULT nextval('categories_id_seq'::regclass),
    name character varying(50) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE public.questions (
    id integer NOT NULL DEFAULT nextval('questions_id_seq'::regclass),
    category_id integer,
    question text NOT NULL, UNIQUE
    option_a text NOT NULL,
    option_b text NOT NULL,
    option_c text NOT NULL,
    option_d text NOT NULL,
    correct_option character(1) NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (category_id) REFERENCES public.categories(id)
);

CREATE TABLE public.scores (
    id integer NOT NULL DEFAULT nextval('scores_id_seq'::regclass),
    user_id integer,
    score integer NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (user_id) REFERENCES public.users(id)
);

CREATE TABLE public.users (
    id integer NOT NULL DEFAULT nextval('users_id_seq'::regclass),
    username character varying(50) NOT NULL UNIQUE,
    best_score integer DEFAULT 0,
    PRIMARY KEY (id)
);

-- Data för kategorier
INSERT INTO public.categories VALUES (1, 'General Knowledge');
INSERT INTO public.categories VALUES (2, 'Science');
INSERT INTO public.categories VALUES (3, 'Math');
INSERT INTO public.categories VALUES (4, 'History');

-- Data för frågor
INSERT INTO public.questions VALUES (9, 1, 'What is the capital of France?', 'Paris', 'London', 'Berlin', 'Madrid', 'A');
INSERT INTO public.questions VALUES (10, 1, 'Who wrote "Hamlet"?', 'Shakespeare', 'Dickens', 'Hemingway', 'Tolkien', 'A');
INSERT INTO public.questions VALUES (11, 1, 'What is the boiling point of water?', '100°C', '90°C', '110°C', '80°C', 'A');
-- (Fler frågor har också sparats men förkortats här för utrymmets skull)

-- Data för användare
INSERT INTO public.users VALUES (1, 'zanakadir', 2);
INSERT INTO public.users VALUES (2, 'kadir', 4);
