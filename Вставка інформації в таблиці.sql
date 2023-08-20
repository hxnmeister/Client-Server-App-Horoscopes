insert into ZodiacSigns (Id, Name)
values (1, 'CAPRICORN'), (2, 'AQUARIUS'), (3, 'PISCES'), (4, 'ARIES'), (5, 'TAURUS'), (6, 'GEMINI'),
(7, 'CANCER'), (8, 'LEO'), (9, 'VIRGO'), (10, 'LIBRA'), (11, 'SCORPIO'), (12, 'SAGITTARIUS')

insert into Predictions(Id, Content)
values 
(1, 'Luck is something you have to work for. If you seem to have an incredible streak of luck today, its probably because you did something earlier to make it happen!'), 
(2, 'If you get asked to lead a team in your personal or professional life, jump at the chance.'), 
(3, 'Today you will get all the support you need.'), 
(4, 'Dont be afraid that youre not good enough.'), 
(5, 'You couldnt dream of a better day to deal with all the little problems in your daily life - broken washing machine, money problems, minor health issues.'), 
(6, 'If your doctor has given you a prescription, you can expect it would work like a miracle drug, take care of the little things. It will take less time than you think!'),
(7, 'Perhaps you cant believe it, but its time to say goodbye to your rigid attitude. '), 
(8, 'A little pleasure among all that seriousness and responsibility wont do you any harm.'),
(9, 'This day could help you change your point of view on life. This will feel great!'), 
(10, 'Life is helping you out at the moment. Whatever it is, your guardian angel is always by your side.'), 
(11, 'Perhaps youd like to begin something new in your life, like moving or changing lifestyles. At the moment you can do anything you want to do.'), 
(12, 'Its time to show the world that you have a gift and that people can count on you to do a great job. Think about the publishing business.')

insert into ZodiacsPredictions (Id, ZodiacSignId, PredictionId)
values (1, 8, 4), (2, 2, 12), (3, 5, 11), (4, 12, 9), (5, 7, 5), (6, 3, 6), (7, 6, 1), (8, 9, 8), (9, 10, 3), 
(10, 11, 7), (11, 4, 2), (12, 1, 10)