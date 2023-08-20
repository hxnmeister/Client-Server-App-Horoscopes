create table ZodiacSigns
(
	Id int not null primary key,
	Name varchar(11) not null
)

create table Predictions
(
	Id int not null primary key,
	Content varchar(1000) not null
)

create table ZodiacsPredictions
(
	Id int not null primary key,
	ZodiacSignId int not null,
	PredictionId int not null

	foreign key (ZodiacSignId) references ZodiacSigns(Id),
	foreign key (PredictionId) references Predictions(Id)
)