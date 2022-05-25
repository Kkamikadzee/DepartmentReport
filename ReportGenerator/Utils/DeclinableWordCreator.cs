using Cyriller;
using Cyriller.Model;
using ReportGenerator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGenerator.Utils
{
    public class DeclinableWordCreator
    {
        private static readonly Lazy<DeclinableWordCreator> LazyInstance
            = new Lazy<DeclinableWordCreator>(() => new DeclinableWordCreator());

        private readonly CyrNounCollection _cyrNounCollection;
        private readonly CyrAdjectiveCollection _cyrAdjectiveCollection;

        public static DeclinableWordCreator Instance => LazyInstance.Value;

        public DeclinableWordCreator()
        {
            _cyrNounCollection = new CyrNounCollection();
            _cyrAdjectiveCollection = new CyrAdjectiveCollection();
        }

        public DeclinableWord Create(string word)
        {
#if DEBUG
            return NoLoadCollectionsCreate(word);
#else
            return CreateHelper(word);
#endif
        }

        private DeclinableWord CreateHelper(string word)
        {
            var word_ = word.ToLower();
            var cyrResult = _cyrNounCollection.GetOrDefault(word_, out CasesEnum @caseNoun, out NumbersEnum numberNoun)
                ?.Decline()
                ??
                _cyrAdjectiveCollection.GetOrDefault(word_, out GendersEnum gender, out CasesEnum @caseAdjective, out NumbersEnum numberAdjective, out AnimatesEnum animate)
                ?.Decline(gender, animate);

            return new DeclinableWord(cyrResult);
        }

        private DeclinableWord NoLoadCollectionsCreate(string word)
        {
            var cyrResult = new CyrNoun(word,
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

            return new DeclinableWord(cyrResult);
        }
    }
}
