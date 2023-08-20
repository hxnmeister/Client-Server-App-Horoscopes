select ZS.Name as [Zodiac Name], P.Content as Prediction
from ZodiacSigns as ZS join ZodiacsPredictions as ZP
on ZS.Id = ZP.ZodiacSignId join Predictions as P
on P.Id = ZP.PredictionId
where ZS.Name = 'Scorpio'