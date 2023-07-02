namespace VowelRecognition.Step6_Classification
{
    public static class VowelClassificationInformation
    {
        public static IVowelFormantClassifier[] VocalClassifiersDistance = 
        {
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(780, 1.0),
                new DistanceAffilationCalculator(1500, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 1, Name = "a" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(800, 1.0),
                new DistanceAffilationCalculator(1400, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 2, Name = "a:" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(400, 1.0),
                new DistanceAffilationCalculator(2300, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 3, Name = "e" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(550, 1.0),
                new DistanceAffilationCalculator(2100, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 4, Name = "ɛ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(550, 1.0),
                new DistanceAffilationCalculator(2200, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 5, Name = "ɛ:" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(400, 1.0),
                new DistanceAffilationCalculator(2000, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 6, Name = "ɪ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(300, 1.0),
                new DistanceAffilationCalculator(2400, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 7, Name = "i" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(600, 1.0),
                new DistanceAffilationCalculator(1150, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 8, Name = "ɔ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(400, 1.0),
                new DistanceAffilationCalculator(850, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 9, Name = "o" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(420, 1.0),
                new DistanceAffilationCalculator(1050, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 10, Name = "ʊ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(330, 1.0),
                new DistanceAffilationCalculator(900, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 11, Name = "u" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(400, 1.0),
                new DistanceAffilationCalculator(1600, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 12, Name = "ʏ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(310, 1.0),
                new DistanceAffilationCalculator(1750, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 13, Name = "y" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(520, 1.0),
                new DistanceAffilationCalculator(1550, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 14, Name = "œ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(400, 1.0),
                new DistanceAffilationCalculator(1550, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 15, Name = "ø" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new DistanceAffilationCalculator(540, 1.0),
                new DistanceAffilationCalculator(1550, 1.0),
                new LogisticRegressionClassifier(new ClassInfo { Id = 16, Name = "ə" }, new[] { 0.7, 1.0 })
            ),
        };



        public static IVowelFormantClassifier[] VocalClassifiers_LR = 
        {
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(500, 600, 1100, 1200),
                new LRIntervallAffilationCalculator(1100, 1300, 1700, 1900),
                new LogisticRegressionClassifier(new ClassInfo { Id = 1, Name = "a" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(600, 650, 950, 1100),
                new LRIntervallAffilationCalculator(1000, 1150, 1600, 1750),
                new LogisticRegressionClassifier(new ClassInfo { Id = 2, Name = "a:" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(200, 250, 500, 550),
                new LRIntervallAffilationCalculator(1800, 1950, 2700, 2900),
                new LogisticRegressionClassifier(new ClassInfo { Id = 3, Name = "e" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(350, 400, 700, 750),
                new LRIntervallAffilationCalculator(1600, 1650, 2400, 2500),
                new LogisticRegressionClassifier(new ClassInfo { Id = 4, Name = "ɛ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(350, 400, 700, 750),
                new LRIntervallAffilationCalculator(1700, 1750, 2500, 2600),
                new LogisticRegressionClassifier(new ClassInfo { Id = 5, Name = "ɛ:" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(200, 250, 500, 600),
                new LRIntervallAffilationCalculator(1600, 1700, 2300, 2500),
                new LogisticRegressionClassifier(new ClassInfo { Id = 6, Name = "ɪ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(150, 200, 400, 450),
                new LRIntervallAffilationCalculator(1950, 2000,2800, 3000),
                new LogisticRegressionClassifier(new ClassInfo { Id = 7, Name = "i" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(400, 450, 700, 750),
                new LRIntervallAffilationCalculator(850, 900,1350, 1450),
                new LogisticRegressionClassifier(new ClassInfo { Id = 8, Name = "ɔ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(250, 300, 500, 550),
                new LRIntervallAffilationCalculator(600, 650,1100, 1200),
                new LogisticRegressionClassifier(new ClassInfo { Id = 9, Name = "o" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(230, 280, 530, 600),
                new LRIntervallAffilationCalculator(700, 800,1250, 1350),
                new LogisticRegressionClassifier(new ClassInfo { Id = 10, Name = "ʊ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(180, 230, 430, 500),
                new LRIntervallAffilationCalculator(600, 650,1150, 1300),
                new LogisticRegressionClassifier(new ClassInfo { Id = 11, Name = "u" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(250, 280, 520, 570),
                new LRIntervallAffilationCalculator(1250, 1350,1850, 2000),
                new LogisticRegressionClassifier(new ClassInfo { Id = 12, Name = "ʏ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(150, 180, 420, 480),
                new LRIntervallAffilationCalculator(1450, 1550,2000, 2200),
                new LogisticRegressionClassifier(new ClassInfo { Id = 13, Name = "y" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(320, 370, 650, 720),
                new LRIntervallAffilationCalculator(1250, 1350,1850, 1950),
                new LogisticRegressionClassifier(new ClassInfo { Id = 14, Name = "œ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(230, 280, 530, 600),
                new LRIntervallAffilationCalculator(1350, 1450,1800, 1900),
                new LogisticRegressionClassifier(new ClassInfo { Id = 15, Name = "ø" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRIntervallAffilationCalculator(380, 420, 700, 750),
                new LRIntervallAffilationCalculator(1200, 1300,1950, 2100),
                new LogisticRegressionClassifier(new ClassInfo { Id = 16, Name = "ə" }, new[] { 0.7, 1.0 })
            ),
        };


        public static IVowelFormantClassifier[] VocalClassifiers_LRM = 
        {
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(500, 600, 780, 1100, 1200),
                new LRMIntervallAffilationCalculator(1100, 1300, 1500,1700, 1900),
                new LogisticRegressionClassifier(new ClassInfo { Id = 1, Name = "a" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(600, 650, 800, 950, 1100),
                new LRMIntervallAffilationCalculator(1000, 1150, 1400,1600, 1750),
                new LogisticRegressionClassifier(new ClassInfo { Id = 2, Name = "a:" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(200, 250, 400, 500, 550),
                new LRMIntervallAffilationCalculator(1800, 1950, 2300,2700, 2900),
                new LogisticRegressionClassifier(new ClassInfo { Id = 3, Name = "e" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(350, 400, 550, 700, 750),
                new LRMIntervallAffilationCalculator(1600, 1650, 2100,2400, 2500),
                new LogisticRegressionClassifier(new ClassInfo { Id = 4, Name = "ɛ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(350, 400, 550, 700, 750),
                new LRMIntervallAffilationCalculator(1700, 1750, 2200,2500, 2600),
                new LogisticRegressionClassifier(new ClassInfo { Id = 5, Name = "ɛ:" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(200, 250, 400, 500, 600),
                new LRMIntervallAffilationCalculator(1600, 1700, 2000,2300, 2500),
                new LogisticRegressionClassifier(new ClassInfo { Id = 6, Name = "ɪ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(150, 200, 300, 400, 450),
                new LRMIntervallAffilationCalculator(1950, 2000, 2400,2800, 3000),
                new LogisticRegressionClassifier(new ClassInfo { Id = 7, Name = "i" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(400, 450, 600, 700, 750),
                new LRMIntervallAffilationCalculator(850, 900, 1150,1350, 1450),
                new LogisticRegressionClassifier(new ClassInfo { Id = 8, Name = "ɔ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(250, 300, 400, 500, 550),
                new LRMIntervallAffilationCalculator(600, 650, 850,1100, 1200),
                new LogisticRegressionClassifier(new ClassInfo { Id = 9, Name = "o" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(230, 280, 420, 530, 600),
                new LRMIntervallAffilationCalculator(700, 800, 1050,1250, 1350),
                new LogisticRegressionClassifier(new ClassInfo { Id = 10, Name = "ʊ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(180, 230, 330, 430, 500),
                new LRMIntervallAffilationCalculator(600, 650, 900,1150, 1300),
                new LogisticRegressionClassifier(new ClassInfo { Id = 11, Name = "u" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(250, 280, 400, 520, 570),
                new LRMIntervallAffilationCalculator(1250, 1350, 1600,1850, 2000),
                new LogisticRegressionClassifier(new ClassInfo { Id = 12, Name = "ʏ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(150, 180, 310, 420, 480),
                new LRMIntervallAffilationCalculator(1450, 1550, 1750,2000, 2200),
                new LogisticRegressionClassifier(new ClassInfo { Id = 13, Name = "y" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(320, 370, 520, 650, 720),
                new LRMIntervallAffilationCalculator(1250, 1350, 1550,1850, 1950),
                new LogisticRegressionClassifier(new ClassInfo { Id = 14, Name = "œ" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(230, 280, 400, 530, 600),
                new LRMIntervallAffilationCalculator(1350, 1450, 1550,1800, 1900),
                new LogisticRegressionClassifier(new ClassInfo { Id = 15, Name = "ø" }, new[] { 0.7, 1.0 })
            ),
            new VowelFormantClassifier
            (
                new LRMIntervallAffilationCalculator(380, 420, 540, 700, 750),
                new LRMIntervallAffilationCalculator(1200, 1300, 1550,1950, 2100),
                new LogisticRegressionClassifier(new ClassInfo { Id = 16, Name = "ə" }, new[] { 0.7, 1.0 })
            ),
        };
    }
}
