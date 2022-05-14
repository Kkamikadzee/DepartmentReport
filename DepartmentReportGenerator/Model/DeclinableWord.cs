using Cyriller;
using System;
using Cyriller.Model;

namespace DepartmentReportGenerator.Model
{
    public class DeclinableWord
    {
        // TODO: Убрать эти статические поля отсюда.
        // private static readonly CyrNounCollection CyrNounCollection = new CyrNounCollection();
        // private static readonly CyrAdjectiveCollection CyrAdjectiveCollection = new CyrAdjectiveCollection();
        // private static readonly CyrPhrase CyrPhrase = new CyrPhrase(CyrNounCollection, CyrAdjectiveCollection);

        private readonly string _word;
        private readonly CyrResult _cyrResult;
        
        public string Nominative => _cyrResult.Nominative;
        public string Genitive => _cyrResult.Genitive;
        public string Dative => _cyrResult.Dative;
        public string Accusative => _cyrResult.Accusative;
        public string Instrumental => _cyrResult.Instrumental;
        public string Prepositional => _cyrResult.Prepositional;

        public DeclinableWord(string word)
        {
            _word = word;
            _cyrResult = new CyrNoun(word,
                GendersEnum.Feminine,
                AnimatesEnum.Animated,
                WordTypesEnum.Abbreviation,
                new CyrRule[]
                {
                    new CyrRule("0"),
                    new CyrRule("1"),
                    new CyrRule("2"),
                    new CyrRule("3"),
                    new CyrRule("4"),
                    new CyrRule("5"),
                    new CyrRule("6"),
                    new CyrRule("7"),
                    new CyrRule("8"),
                    new CyrRule("9"),
                    new CyrRule("10")
                }).Decline();
            // TODO: Раскомментировать строку
            // _cyrResult = CyrPhrase.Decline(word, GetConditionsEnum.Similar);
        }

        public override string ToString()
        {
            return Nominative;
        }
    }
}