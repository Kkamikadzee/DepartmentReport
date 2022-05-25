using Cyriller;

namespace ReportGenerator.Model
{
    public class DeclinableWord
    {
        private readonly CyrResult _cyrResult;
        
        public string Nominative => _cyrResult.Nominative;
        public string Genitive => _cyrResult.Genitive;
        public string Dative => _cyrResult.Dative;
        public string Accusative => _cyrResult.Accusative;
        public string Instrumental => _cyrResult.Instrumental;
        public string Prepositional => _cyrResult.Prepositional;

        public DeclinableWord(CyrResult сyrResult)
        {
            _cyrResult = сyrResult;
        }

        public override string ToString()
        {
            return Nominative;
        }
    }
}