-- Skapande av tabeller
-- Kategori tavla
CREATE TABLE public.categories (
    id integer NOT NULL DEFAULT nextval('categories_id_seq'::regclass),
    name character varying(50) NOT NULL,
    PRIMARY KEY (id)
);

-- Fråge tavla 
CREATE TABLE public.questions (
    id integer NOT NULL DEFAULT nextval('questions_id_seq'::regclass),
    category_id integer,
    question text NOT NULL,
    option_a text NOT NULL,
    option_b text NOT NULL,
    option_c text NOT NULL,
    option_d text NOT NULL,
    correct_option character(1) NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (category_id) REFERENCES public.categories(id)
);

-- Användarens poäng tavla
CREATE TABLE public.scores (
    id integer NOT NULL DEFAULT nextval('scores_id_seq'::regclass),
    user_id integer,
    score integer NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (user_id) REFERENCES public.users(id)
);

-- Användar tavla
CREATE TABLE public.users (
    id integer NOT NULL DEFAULT nextval('users_id_seq'::regclass),
    username character varying(50) NOT NULL UNIQUE,
    best_score integer DEFAULT 0,
    PRIMARY KEY (id)
);

-- Data för kategorier
INSERT INTO public.categories (id, name) VALUES (5, 'Spel');
INSERT INTO public.categories (id, name) VALUES (6, 'Programmering');
INSERT INTO public.categories (id, name) VALUES (7, 'Filmer');

-- Data för frågor - Spel kategori
INSERT INTO public.questions (category_id, question, option_a, option_b, option_c, option_d, correct_option) 
VALUES
(5, 'Vilken färg har Mario på sina skor?', 'Svart', 'Grå', 'Brun', 'Blå', 'C'),
(5, 'Vilket djur är Sonic?', 'Mus', 'Kanin', 'Katt', 'Igelkott', 'D'),
(5, 'Vilket spel är John Cena med i?', 'UFC', 'Street Fighter', 'Tekken', 'WWE', 'D'),
(5, 'I League of Legends finns en champion som heter Nasus, vilken lane kör man honom?', 'Jungle', 'Top lane', 'Mid lane', 'Bot lane', 'B'),
(5, 'Hur varvar man klart Minecraft i Survival Mode?', 'Besegra Herobrine', 'Få full Diamond Armor', 'Besegra Witcher', 'Besegra Ender Dragon', 'D');

-- Data för frågor - Programmering kategori
INSERT INTO public.questions (category_id, question, option_a, option_b, option_c, option_d, correct_option) 
VALUES
(6, 'Hur många bitar har datatypen Long?', '32 bitar', '64 bitar', '8 bitar', '128 bitar', 'B'),
(6, 'Vilken av följande är inte en giltig datatyp i C#?', 'Integer', 'Decimal', 'String', 'Double', 'A'),
(6, 'Vilket språk används som grund för Frontend?', 'XML', 'HTML', 'Java', 'SQL', 'B'),
(6, 'Vad kommer följande kod skriva ut?\nint[] numbers = { 1, 2, 3, 4, 5 };\nConsole.WriteLine(numbers[5]);', '5', '0', 'NullReferenceException', 'IndexOutOfRangeException', 'D'),
(6, 'Vad betyder NULL i programmering?', 'Tom sträng', 'Felmeddelande', 'Objektreferensfel', 'Inget värde', 'D');

-- Data för frågor - Filmer kategori
INSERT INTO public.questions (category_id, question, option_a, option_b, option_c, option_d, correct_option) 
VALUES
(7, 'Vad heter ringen som Frodo måste förstöra i Sagan om Ringen?', 'The Ring of Power', 'The One Ring', 'The Elven Ring', 'The Dark Ring', 'B'),
(7, 'Vilken stad är huvudplatsen för handlingen i filmen Inception?', 'Paris', 'Tokyo', 'Los Angeles', 'New York', 'A'),
(7, 'Vad heter huvudkaraktären i filmen Pirates of the Caribbean?', 'Will Turner', 'Hector Barbossa', 'Jack Sparrow', 'Davy Jones', 'C'),
(7, 'Vilken regissör är känd för filmer som Pulp Fiction och Kill Bill?', 'Christopher Nolan', 'Martin Scorsese', 'Steven Spielberg', 'Quentin Tarantino', 'D'),
(7, 'Vilken animerad Disney-film innehåller låten Let It Go?', 'Moana', 'Tangled', 'Frozen', 'The Little Mermaid', 'C');

-- Data för användare
INSERT INTO public.users (id, username, best_score) VALUES (1, 'zanakadir', 2);
INSERT INTO public.users (id, username, best_score) VALUES (2, 'kadir', 4);
