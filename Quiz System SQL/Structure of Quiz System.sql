Create database QuizSystem


Create table Admins
(
	AdminID int primary key identity(1,1),
	Name varchar(100) not null,
	Email varchar(100) not null unique	Check(Email like '%@%.%' and Email not like '@%' and Email not like '%@.%' and Email not like '%.' and Email not like '%.@%' and Email not like '% %' and Email not like '%@%@%'),
	Password varchar(256) not null Check(Password like '%[A-Z]%' and Password like '%[a-z]%' and Password like '%[0-9]%' and len(Password) >= 8)
)

Create table Students
(
	StudentID int primary key identity(1,1),
	Name varchar(100) not null,
	Grade char not null check(Grade in('A','B','C','D','F','U')) Default 'U',
	Email varchar(100) not null unique	Check(Email like '%@%.%' and Email not like '@%' and Email not like '%@.%' and Email not like '%.' and Email not like '%.@%' and Email not like '% %' and Email not like '%@%@%'),
	Password varchar(256) not null Check(Password like '%[A-Z]%' and Password like '%[a-z]%' and Password like '%[0-9]%' and len(Password) >= 8)
)

Create table Teachers
(
	TeacherID int primary key identity(1,1),
	Title varchar(50) not null Check(Title in('Substitute','ClassroomTeacher','Specialist','LeadTeacher','DepartmentHead','AcademicCoordinator','UnAssigned')) Default 'UnAssigned' ,
	Name varchar(100) not null,
	Email varchar(100) not null unique	Check(Email like '%@%.%' and Email not like '@%' and Email not like '%@.%' and Email not like '%.' and Email not like '%.@%' and Email not like '% %' and Email not like '%@%@%'),
	Password varchar(256) not null Check(Password like '%[A-Z]%' and Password like '%[a-z]%' and Password like '%[0-9]%' and len(Password) >= 8)
)

Create table Courses --1:N relationship with Teachers and Administrators
(
	CourseID int primary key identity(1,1),
	CourseName varchar(100) not null unique,
	CourseDuration int not null check(CourseDuration > 0), --Duration in Hours
	Status varchar(20) not null check(Status in('Assigned','UnAssigned')) default 'UnAssigned',
	Category varchar(50) not null check(Category in('Math','Science','Mechanics','Programming','English','UnAssigned')) default 'UnAssigned',
	NumberOfLessons int not null check(NumberOfLessons > 0),
	TeacherID int default null,
	AdminID int not null,
	foreign key (TeacherID) references Teachers(TeacherID),
	foreign key (AdminID) references Admins(AdminID),

)

Create table Enrollments --N:N relationship between Students and Courses
(
	StudentID int not null,
	CourseID int not null,
	primary key (StudentID, CourseID),
	foreign key (StudentID) references Students(StudentID),
	foreign key (CourseID) references Courses(CourseID)
)

Create table Quizzes --1:N relationship with Courses
(
	QuizID int primary key identity(1,1),
	QuizName varchar(100) not null,
	QuizDuration int not null check(QuizDuration > 0),--Duration in Seconds
	CourseID int not null,
	foreign key (CourseID) references Courses(CourseID)
)

Create table Questions --1:N relationship with Quizzes
(
	QuestionID int primary key identity(1,1),
	QuestionBody varchar(500) not null,
	QuestionType varchar(20) not null check(QuestionType in('MCQ','TrueFalse','ShortAnswer')) default 'ShortAnswer',
	Answer varchar(500) not null,
	QuizID int not null,
	foreign key (QuizID) references Quizzes(QuizID)
)

Create table Choices--1:N relationship with Questions for MCQ type questions
(
	ChoiceID int primary key identity(1,1),
	ChoiceText varchar(200) not null,
	QuestionID int not null,
	foreign key (QuestionID) references Questions(QuestionID)
)


Create table QuizAttempts --N:N relationship between Students and Quizzes
(
	StudentID int not null,
	QuizID int not null,
	DurationTook int not null check(DurationTook >= 0),--Duration in Seconds
	Score int not null check(Score >= 0 and Score <= 100),
	primary key (StudentID, QuizID),
	foreign key (StudentID) references Students(StudentID),
	foreign key (QuizID) references Quizzes(QuizID)
)

Create table StudentAnswer --Student answer for each question in the quiz
(
	StudentID int not null,
	QuestionID int not null,
	Answer varchar(500) not null,
	primary key (StudentID, QuestionID),
	foreign key (StudentID) references Students(StudentID),
	foreign key (QuestionID) references Questions(QuestionID)
)

Alter table Courses
add constraint chk_TeacherID_Status check ((TeacherID is null and Status = 'UnAssigned') or (TeacherID is not null and Status = 'Assigned'))

INSERT INTO Admins (Name, Email, Password)
VALUES 
('AdminA', 'Admin1@gmail.com', 'AdminA123'),
('AdminB', 'Admin2@gmail.com', 'AdminB123'),
('AdminC', 'Admin3@gmail.com', 'AdminC123'),
('AdminD', 'Admin4@gmail.com', 'AdminD123'),
('AdminE', 'Admin5@gmail.com', 'AdminE123'),
('AdminF', 'Admin6@gmail.com', 'AdminF123'),
('AdminG', 'Admin7@gmail.com', 'AdminG123'),
('AdminH', 'Admin8@gmail.com', 'AdminH123'),
('AdminI', 'Admin9@gmail.com', 'AdminI123'),
('AdminJ', 'Admin10@gmail.com', 'AdminJ123'),
('AdminK', 'Admin11@gmail.com', 'AdminK123'),
('AdminL', 'Admin12@gmail.com', 'AdminL123'),
('AdminM', 'Admin13@gmail.com', 'AdminM123'),
('AdminN', 'Admin14@gmail.com', 'AdminN123'),
('AdminO', 'Admin15@gmail.com', 'AdminO123'),
('AdminP', 'Admin16@gmail.com', 'AdminP123'),
('AdminQ', 'Admin17@gmail.com', 'AdminQ123'),
('AdminR', 'Admin18@gmail.com', 'AdminR123'),
('AdminS', 'Admin19@gmail.com', 'AdminS123'),
('AdminT', 'Admin20@gmail.com', 'AdminT123');

INSERT INTO Teachers (Title, Name, Email, Password)
VALUES 
('ClassroomTeacher', 'TeacherA', 'Teacher1@gmail.com', 'TeacherA123'),
('DepartmentHead', 'TeacherB', 'Teacher2@gmail.com', 'TeacherB123'),
('Specialist', 'TeacherC', 'Teacher3@gmail.com', 'TeacherC123'),
('LeadTeacher', 'TeacherD', 'Teacher4@gmail.com', 'TeacherD123'),
('AcademicCoordinator', 'TeacherE', 'Teacher5@gmail.com', 'TeacherE123'),
('Substitute', 'TeacherF', 'Teacher6@gmail.com', 'TeacherF123'),
('ClassroomTeacher', 'TeacherG', 'Teacher7@gmail.com', 'TeacherG123'),
('ClassroomTeacher', 'TeacherH', 'Teacher8@gmail.com', 'TeacherH123'),
('Specialist', 'TeacherI', 'Teacher9@gmail.com', 'TeacherI123'),
('LeadTeacher', 'TeacherJ', 'Teacher10@gmail.com', 'TeacherJ123'),
('ClassroomTeacher', 'TeacherK', 'Teacher11@gmail.com', 'TeacherK123'),
('DepartmentHead', 'TeacherL', 'Teacher12@gmail.com', 'TeacherL123'),
('UnAssigned', 'TeacherM', 'Teacher13@gmail.com', 'TeacherM123'),
('ClassroomTeacher', 'TeacherN', 'Teacher14@gmail.com', 'TeacherN123'),
('Specialist', 'TeacherO', 'Teacher15@gmail.com', 'TeacherO123'),
('Substitute', 'TeacherP', 'Teacher16@gmail.com', 'TeacherP123'),
('ClassroomTeacher', 'TeacherQ', 'Teacher17@gmail.com', 'TeacherQ123'),
('AcademicCoordinator', 'TeacherR', 'Teacher18@gmail.com', 'TeacherR123'),
('LeadTeacher', 'TeacherS', 'Teacher19@gmail.com', 'TeacherS123'),
('ClassroomTeacher', 'TeacherT', 'Teacher20@gmail.com', 'TeacherT123');

INSERT INTO Students (Name, Grade, Email, Password)
VALUES 
('StudentA', 'A', 'Student1@gmail.com', 'StudentA123'),
('StudentB', 'B', 'Student2@gmail.com', 'StudentB123'),
('StudentC', 'A', 'Student3@gmail.com', 'StudentC123'),
('StudentD', 'C', 'Student4@gmail.com', 'StudentD123'),
('StudentE', 'B', 'Student5@gmail.com', 'StudentE123'),
('StudentF', 'U', 'Student6@gmail.com', 'StudentF123'),
('StudentG', 'A', 'Student7@gmail.com', 'StudentG123'),
('StudentH', 'D', 'Student8@gmail.com', 'StudentH123'),
('StudentI', 'B', 'Student9@gmail.com', 'StudentI123'),
('StudentJ', 'A', 'Student10@gmail.com', 'StudentJ123'),
('StudentK', 'C', 'Student11@gmail.com', 'StudentK123'),
('StudentL', 'B', 'Student12@gmail.com', 'StudentL123'),
('StudentM', 'F', 'Student13@gmail.com', 'StudentM123'),
('StudentN', 'A', 'Student14@gmail.com', 'StudentN123'),
('StudentO', 'U', 'Student15@gmail.com', 'StudentO123'),
('StudentP', 'B', 'Student16@gmail.com', 'StudentP123'),
('StudentQ', 'A', 'Student17@gmail.com', 'StudentQ123'),
('StudentR', 'C', 'Student18@gmail.com', 'StudentR123'),
('StudentS', 'D', 'Student19@gmail.com', 'StudentS123'),
('StudentT', 'A', 'Student20@gmail.com', 'StudentT123');

Insert into Courses (CourseName, CourseDuration, Status, Category, NumberOfLessons, TeacherID, AdminID)
Values
('Math 101', 70, 'Assigned', 'Math', 10, 1, 1),
('Science 101', 45, 'Assigned', 'Science', 12, 2, 2),
('Mechanics 101', 50, 'Assigned', 'Mechanics', 15, 3, 3),
('Programming 101', 60, 'Assigned', 'Programming', 20, 4, 4),
('English 101', 30, 'Assigned', 'English', 8, 5, 5),
('Math 102', 40, 'Assigned', 'Math', 10, 7, 6),
('Science 102', 45, 'Assigned', 'Science', 12, 2, 7),
('Mechanics 102', 50, 'Assigned', 'Mechanics', 15, 7, 8),
('Programming 102', 60, 'Assigned', 'Programming', 20, 3,9),
('English 102',20,'Assigned','English',8,1,10),
('Math 103', 35, 'Assigned', 'Math', 10, 3, 11),
('Science 103', 40, 'UnAssigned', 'Science', 12, null, 12),
('Mechanics 103', 45, 'UnAssigned', 'Mechanics', 15, null, 13),
('Programming 103', 55, 'UnAssigned', 'Programming', 20, null,14),
('English 103',25,'UnAssigned','English',8,null,15),
('Math 104', 30, 'UnAssigned', 'Math', 10, null,16),
('Science 104', 35, 'UnAssigned', 'Science', 12, null,17),
('Mechanics 104', 40, 'UnAssigned', 'Mechanics', 15, null,18),
('Programming 104',50,'UnAssigned','Programming',20,null,19),
('English 104',15,'UnAssigned','English',8,null,20),
('Math 105', 25, 'UnAssigned', 'Math', 10, null, 1);

Insert into Enrollments (StudentID, CourseID)
Values
(1, 1),
(2, 1),
(3, 2),
(4, 2),
(2, 3),
(4, 3),
(7, 4),
(8, 4),
(2, 5),
(10, 5),
(11, 6),
(12, 6),
(13, 7),
(14, 7),
(3, 8),
(16, 8),
(17, 9),
(11, 9),
(12, 10),
(13, 10);

Insert into Quizzes (QuizName, QuizDuration, CourseID)
Values
('Quiz 1 Math', 30, 1),
('Quiz 1 Science', 25, 2),
('Quiz 1 Mechanics', 35, 3),
('Quiz 1 Programming', 40, 4),
('Quiz 1 English', 20, 5),
('Quiz 2 Math', 30, 1),
('Quiz 2 Science', 25, 2),
('Quiz 2 Mechanics', 35, 3),
('Quiz 2 Programming', 40, 4),
('Quiz 2 English',20,5),
('Quiz 3 Math', 30, 6),
('Quiz 3 Science', 25, 7),
('Quiz 3 Mechanics', 35, 8),
('Quiz 3 Programming', 40, 9),
('Quiz 3 English',20,10),
('Quiz 4 Math', 30, 1),
('Quiz 4 Science', 25, 2),
('Quiz 4 Mechanics', 35, 3),
('Quiz 4 Programming', 40, 4),
('Quiz 4 English',20,5);

Insert into Questions (QuestionBody, QuestionType, Answer, QuizID)
Values
('What is 2 + 2?', 'MCQ', '4', 1),
('What is the chemical symbol for water?', 'ShortAnswer', 'H2O', 2),
('What is the formula for force?', 'ShortAnswer', 'F = m * a', 3),
('What is the output of print(2 + 3) in Python?', 'ShortAnswer', '5', 4),
('What is the synonym of "happy"?', 'ShortAnswer', 'joyful', 5),
('What is 5 * 6?', 'MCQ', '30', 6),
('What is the chemical symbol for carbon dioxide?', 'ShortAnswer', 'CO2', 7),
('What is the formula for kinetic energy?', 'ShortAnswer', 'KE = 0.5 * m * v^2', 8),
('What is the output of print("Hello" + "World") in Python?', 'ShortAnswer', 'HelloWorld', 9),
('What is the antonym of "hot"?', 'ShortAnswer', 'cold', 10),
('What is 10 / 2?', 'MCQ', '5', 11),
('What is the chemical symbol for oxygen?', 'ShortAnswer', 'O2', 12),
('What is the formula for potential energy?', 'ShortAnswer', 'PE = m * g * h', 13),
('What is the output of print(10 % 3) in Python?', 'ShortAnswer', '1', 14),
('What is the synonym of "sad"?', 'ShortAnswer', 'unhappy', 15),
('What is 8 - 3?', 'MCQ', '5', 16),
('What is the chemical symbol for sodium?', 'ShortAnswer', 'Na', 17),
('What is the formula for momentum?', 'ShortAnswer', 'p = m * v', 18),
('What is the output of print(4 ** 2) in Python?', 'ShortAnswer', '16', 19),
('What is the antonym of "light"?', 'ShortAnswer', 'dark', 20);


Insert into Questions (QuestionBody, QuestionType, Answer, QuizID)
Values
('C# is a high level language', 'TrueFalse', 'True', 4),
('The Earth is flat', 'TrueFalse', 'False', 2),
('The formula for water is H2O', 'TrueFalse', 'True', 7),
('Python is a programming language', 'TrueFalse', 'True', 9),
('The synonym of "happy" is "sad"', 'TrueFalse', 'False', 5);


Insert into Choices (ChoiceText, QuestionID)
Values
('3', 1),
('4', 1),
('5', 1),
('6', 1),
('40', 6),
('30', 6),
('20', 6),
('10', 6),
('5', 11),
('4', 11),
('3', 11),
('2', 11),
('5', 16),
('4', 16),
('3', 16),
('2', 16);

Insert into Choices (ChoiceText, QuestionID)
Values
('True', 4),
('False', 4),
('True', 2),
('False', 2),
('True', 7),
('False', 7),
('True', 9),
('False', 9),
('True', 5),
('False', 5);


INSERT INTO QuizAttempts (StudentID, QuizID, DurationTook, Score) --I used AI to generate the records :)
VALUES 
(1, 1, 10, 100),   -- Student 1, Quiz 1 (Math 101)
(2, 1, 15, 0),     -- Student 2, Quiz 1 (Got answer wrong)
(1, 6, 12, 100),   -- Student 1, Quiz 6 (Math 102)
(2, 6, 11, 100),   -- Student 2, Quiz 6 (Math 102)
(1, 16, 14, 100),  -- Student 1, Quiz 16 (Math 104)
(2, 16, 10, 100),  -- Student 2, Quiz 16 (Math 104)
(3, 2, 20, 100),   -- Student 3, Quiz 2 (Science 101)
(4, 2, 22, 50),    -- Student 4, Quiz 2 (Got 1 of 2 questions wrong)
(3, 7, 18, 100),   -- Student 3, Quiz 7 (Science 102)
(4, 7, 19, 100),   -- Student 4, Quiz 7 (Science 102)
(2, 3, 30, 100),   -- Student 2, Quiz 3 (Mechanics 101)
(4, 3, 25, 100),   -- Student 4, Quiz 3 (Mechanics 101)
(7, 4, 35, 100),   -- Student 7, Quiz 4 (Programming 101)
(8, 4, 38, 50),    -- Student 8, Quiz 4 (Got 1 of 2 questions wrong)
(2, 5, 10, 100),   -- Student 2, Quiz 5 (English 101)
(10, 5, 15, 100),  -- Student 10, Quiz 5 (English 101)
(11, 11, 12, 100), -- Student 11, Quiz 11 (Math 103)
(12, 11, 14, 100), -- Student 12, Quiz 11 (Math 103)
(13, 12, 20, 100), -- Student 13, Quiz 12 (Science 103)
(14, 12, 18, 100); -- Student 14, Quiz 12 (Science 103)

INSERT INTO StudentAnswer (StudentID, QuestionID, Answer)
VALUES 
-- Attempt 1 & 2 (Quiz 1 - Q1)
(1, 1, '4'),         -- Correct
(2, 1, '3'),         -- Incorrect

-- Attempt 3 & 4 (Quiz 6 - Q6)
(1, 6, '30'),        -- Correct
(2, 6, '30'),        -- Correct

-- Attempt 5 & 6 (Quiz 16 - Q16)
(1, 16, '5'),        -- Correct
(2, 16, '5'),        -- Correct

-- Attempt 7 & 8 (Quiz 2 - Q2 & Q22)
(3, 2, 'H2O'),       -- Correct
(3, 22, 'False'),    -- Correct
(4, 2, 'H2O'),       -- Correct
(4, 22, 'True'),     -- Incorrect

-- Attempt 9 & 10 (Quiz 7 - Q7 & Q23)
(3, 7, 'CO2'),       -- Correct
(3, 23, 'True'),     -- Correct
(4, 7, 'CO2'),       -- Correct
(4, 23, 'True'),     -- Correct

-- Attempt 11 & 12 (Quiz 3 - Q3)
(2, 3, 'F = m * a'), -- Correct
(4, 3, 'F = m * a'), -- Correct

-- Attempt 13 & 14 (Quiz 4 - Q4 & Q21)
(7, 4, '5'),         -- Correct
(7, 21, 'True'),     -- Correct
(8, 4, '5'),         -- Correct
(8, 21, 'False'),    -- Incorrect

-- Attempt 15 & 16 (Quiz 5 - Q5 & Q25)
(2, 5, 'joyful'),    -- Correct
(2, 25, 'False'),    -- Correct
(10, 5, 'joyful'),   -- Correct
(10, 25, 'False'),   -- Correct

-- Attempt 17 & 18 (Quiz 11 - Q11)
(11, 11, '5'),       -- Correct
(12, 11, '5'),       -- Correct

-- Attempt 19 & 20 (Quiz 12 - Q12)
(13, 12, 'O2'),      -- Correct
(14, 12, 'O2');      -- Correct




