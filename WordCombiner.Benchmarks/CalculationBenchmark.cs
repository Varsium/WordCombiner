namespace WordCombiner.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Running;
    using System.Collections.Generic;
    using System.Linq;
    [MaxIterationCount(16)]
    public class CalculationBenchmark
    {
        private readonly List<string> _list = new List<string>() { "pward", "thr", "t", "co", "ddy", "ingle", "towhee", "jus", "sa", "du", "pr", "ks", "buzzer", "cket", "brain", "s", "babie", "am", "outlet", "pavi", "object", "manag", "at", "abies", "anded", "e", "er", "ng", "sa", "arch", "bluis", "narr", "ard", "ue", "sea", "ta", "pepp", "mumb", "r", "st", "toma", "dup", "uiver", "bia", "thrill", "ted", "tem", "nnah", "m", "m", "d", "sarn", "h", "beetl", "nage", "wrym", "bi", "e", "chopi", "forg", "oo", "ter", "sudok", "e", "c", "thirt", "ah", "y", "rescu", "colon", "eved", "nitr", "c", "w", "sy", "ex", "an", "er", "acros", "impact", "york", "ind", "tira", "sh", "sud", "ecade", "ne", "id", "d", "r", "rill", "masses", "ox", "cuckoo", "ct", "cucko", "fan", "fossi", "tomato", "outl", "ver", "pow", "e", "han", "clie", "bel", "er", "es", "wils", "amu", "foye", "pas", "ede", "tiss", "ge", "lead", "gle", "re", "ia", "blui", "o", "b", "clini", "ngle", "lmond", "ju", "natur", "o", "all", "roc", "ato", "p", "ield", "lcan", "le", "th", "rrow", "brook", "nkles", "entry", "epper", "nuka", "sear", "rocket", "th", "ladd", "s", "e", "ying", "sha", "za", "nat", "l", "han", "re", "t", "p", "s", "ony", "du", "acify", "u", "m", "almon", "esto", "ley", "coffe", "wo", "wello", "fema", "petrel", "y", "alt", "nuptse", "broo", "r", "ed", "le", "buzze", "yers", "nt", "ha", "trake", "slovak", "manu", "aggis", "tr", "e", "sod", "ing", "e", "elite", "cend", "sen", "ue", "n", "ocul", "kod", "na", "r", "petre", "queens", "y", "s", "ite", "enrage", "b", "sland", "el", "z", "conni", "ed", "ocket", "ch", "amy", "but", "ifle", "narrow", "bro", "f", "anthe", "t", "ithic", "dur", "shield", "m", "resc", "lay", "y", "e", "deftly", "lidir", "t", "sing", "chan", "l", "foy", "ueens", "end", "rin", "ic", "ocket", "durh", "oddy", "le", "t", "acuum", "mon", "east", "fe", "marton", "inner", "mass", "di", "s", "lovak", "yaw", "uka", "syste", "ill", "impac", "vac", "din", "ser", "ckoo", "cing", "mato", "road", "ri", "inic", "ter", "e", "mo", "female", "vulc", "pacif", "obj", "ler", "ac", "w", "rley", "ro", "hopin", "basal", "citri", "cuc", "nar", "diba", "el", "cuck", "ly", "ch", "belo", "h", "forget", "yawler", "min", "i", "n", "aving", "rocket", "mon", "inf", "ei", "eter", "ht", "har", "inger", "row", "mmon", "a", "ob", "rymug", "asses", "s", "oxfo", "taple", "ooler", "decade", "r", "u", "cloak", "oxfor", "resto", "rton", "pastie", "flig", "act", "indent", "wder", "nded", "so", "m", "rake", "my", "un", "jo", "orrow", "biwan", "yo", "amus", "scalby", "g", "f", "buzz", "obiwan", "ab", "stra", "gmore", "mumbai", "tly", "mi", "a", "now", "comm", "hoddy", "sh", "tissue", "inney", "rkis", "shab", "cit", "er", "b", "rd", "ankle", "nit", "tse", "utmo", "single", "is", "ng", "er", "g", "just", "borr", "ap", "islan", "nger", "shoddy", "opin", "beet", "ward", "ge", "iver", "arkis", "la", "ell", "arch", "i", "ing", "rocke", "asce", "vacu", "nrage", "nie", "ascen", "graves", "ow", "amede", "a", "m", "amedei", "er", "b", "nd", "refl", "ular", "liab", "ug", "fy", "ked", "ring", "eftly", "eder", "issue", "a", "p", "tly", "ame", "ppeal", "de", "d", "ton", "al", "hs", "anage", "utmos", "hin", "ba", "n", "an", "di", "nney", "g", "coff", "tigge", "a", "oat", "ger", "mato", "er", "urham", "s", "by", "amned", "dic", "epict", "rley", "unch", "di", "flex", "wret", "a", "ocular", "th", "sh", "age", "rock", "oyous", "nnow", "occer", "un", "pelit", "abs", "island", "obiwa", "bu", "wr", "vulca", "bar", "zzer", "pla", "smok", "dinner", "hinne", "natu", "ks", "q", "harle", "calby", "xhort", "kodiak", "i", "ify", "ue", "c", "wilted", "lad", "t", "ote", "han", "b", "um", "de", "goog", "hrill", "wre", "mar", "tmost", "cosine", "ct", "cli", "allu", "anuka", "ogle", "hroat", "lit", "lt", "is", "c", "d", "more", "yfan", "er", "llow", "ar", "bo", "dib", "an", "co", "coyot", "ystem", "steamy", "er", "ffee", "ladder", "y", "drinks", "tsy", "c", "socce", "lar", "eamy", "car", "c", "m", "ro", "citr", "exhor", "loo", "n", "to", "amuse", "al", "fil", "a", "s", "emand", "kodi", "clo", "w", "onths", "upw", "sue", "narro", "quee", "t", "narrow", "a", "rget", "o", "hu", "ong", "ent", "o", "edei", "oyote", "app", "user", "d", "r", "ed", "st", "y", "butt", "c", "to", "olony", "shie", "muser", "s", "l", "anet", "wooler", "minno", "f", "t", "g", "ee", "que", "pseud", "ggis", "exeter", "b", "brainy", "dir", "ref", "commo", "do", "client", "ro", "s", "fe", "handed", "af", "o", "lithi", "i", "femal", "be", "bisho", "w", "rescu", "man", "refle", "yorkie", "nks", "w", "gible", "launch", "der", "msy", "rd", "e", "artha", "im", "er", "kle", "ou", "ogmore", "s", "ks", "iing", "e", "mbai", "decad", "kles", "justl", "orkie", "e", "na", "obiwa", "loosen", "e", "nkle", "ex", "lter", "lid", "inde", "thril", "an", "p", "pet", "n", "sy", "tirad", "diak", "sam", "hort", "d", "nce", "x", "fred", "ict", "t", "i", "y", "feeder", "t", "we", "alby", "cu", "aptop", "de", "h", "gis", "r", "sarni", "na", "ed", "lanet", "ai", "allude", "et", "t", "damn", "eal", "nic", "ect", "da", "demand", "offee", "marto", "t", "l", "shod", "asc", "sign", "banked", "re", "er", "tigg", "p", "damne", "ient", "nupt", "d", "loos", "ni", "ntry", "s", "n", "let", "wn", "s", "cur", "j", "c", "o", "s", "ale", "medei", "show", "fossil", "omato", "fo", "r", "ca", "ample", "eld", "bre", "oster", "towh", "peeved", "dinne", "d", "uptow", "ogm", "inden", "rkie", "ir", "ature", "age", "sp", "amuser", "carton", "le", "deman", "d", "p", "on", "queen", "coy", "yawle", "ns", "mond", "bs", "past", "fl", "hagg", "arley", "r", "m", "leade", "y", "unce", "get", "ia", "ies", "can", "strake", "ame", "oad", "s", "le", "s", "bby", "r", "well", "r", "borrow", "hic", "infir", "elidi", "paci", "et", "bo", "quiver", "c", "ce", "b", "w", "wer", "b", "am", "biwan", "ponge", "ure", "oosen", "d", "icing", "l", "b", "l", "sudoku", "g", "uptown", "e", "lapt", "vacuu", "sodi", "ey", "ine", "hirty", "h", "br", "idir", "man", "t", "haggi", "elong", "broad", "ainy", "clu", "ny", "filter", "de", "lithic", "dec", "ross", "wretc", "peli", "nitri", "uniso", "barkis", "eudo", "si", "b", "res", "arton", "ny", "em", "belong", "pper", "ric", "lapto", "am", "ed", "rifle", "town", "own", "ture", "ma", "in", "alf", "kie", "r", "er", "harley", "nature", "exete", "ject", "borro", "iwan", "xford", "s", "raves", "ic", "tri", "ril", "u", "ulcan", "p", "e", "n", "ma", "clums", "e", "d", "prov", "unwel", "tow", "wellow", "land", "feed", "o", "ex", "scue", "slova", "d", "c", "ature", "lea", "tirade", "re", "ee", "tig", "pe", "ba", "t", "en", "ptown", "cho", "xeter", "al", "ti", "wan", "bject", "banke", "wilt", "and", "s", "ade", "nthem", "so", "ow", "utm", "con", "masse", "e", "p", "nter", "nah", "gibl", "shiel", "ee", "hinney", "y", "luish", "ton", "dicing", "ng", "to", "scend", "se", "cloaks", "k", "ader", "duplex", "nths", "ak", "citril", "pl", "tha", "r", "spon", "petr", "ens", "hag", "c", "zam", "rescue", "fo", "e", "koo", "ya", "tom", "wic", "s", "thic", "buc", "ank", "ti", "bis", "ishop", "filte", "cket", "yorki", "ko", "me", "scue", "d", "woo", "ake", "l", "wr", "lex", "tter", "w", "ed", "toma", "as", "prove", "nia", "kis", "ure", "tryfan", "tomato", "etrel", "objec", "f", "ommon", "roste", "aves", "er", "allud", "lfred", "ob", "wilte", "h", "et", "ob", "ty", "lson", "ad", "nt", "r", "pseu", "na", "odiak", "rage", "ch", "smo", "er", "lo", "pasti", "haggis", "udoku", "pa", "doku", "er", "ovak", "buz", "flight", "po", "te", "yawl", "exh", "ankl", "alfred", "ter", "hun", "amed", "lient", "st", "abroad", "d", "red" };
        [Benchmark]
        public void CalculateWithListForeach()
        {
            var words = _list.ToList();
            var output = new List<string>();
            foreach (var word in words)
            {
                foreach (var item in words)
                {
                    string combination = word + item;

                    // Check if the combination forms a valid word
                    if (combination.Length == 6 && !output.Contains($"{word} + {item}={combination}") && word != item)
                    {
                        output.Add($"{word}+{item}={combination}");
                    }
                }
            }
        }

        [Benchmark]
        public void CalculateWithListFor()
        {
            var words = _list.ToList();
            var output = new List<string>();
            for (int i = 0; i < words.Count; i++)
            {
                string? word = words[i];
                for (int j = 0; j < words.Count; j++)
                {
                    string? item = words[j];
                    string combination = word + item;

                    // Check if the combination forms a valid word
                    if (combination.Length == 6 && !output.Contains($"{word} + {item}={combination}") && word != item)
                    {
                        output.Add($"{word}+{item}={combination}");
                    }
                }
            }
        }

        [Benchmark]
        public void CalculateWithHashedListForeach()
        {
            var words = _list.ToHashSet();
            var output = new List<string>();
            foreach (var word in words)
            {
                foreach (var item in words)
                {
                    string combination = word + item;

                    // Check if the combination forms a valid word
                    if (combination.Length == 6 && !output.Contains($"{word} + {item}={combination}") && word != item)
                    {
                        output.Add($"{word}+{item}={combination}");
                    }
                }
            }
        }

        [Benchmark]
        public void CalculateWithHashedListFor()
        {
            var words = _list.ToHashSet();
            var output = new List<string>();
            for (int i = 0; i < words.Count; i++)
            {
                string? word = words.ElementAt(i);
                for (int j = 0; j < words.Count; j++)
                {
                    string? item = words.ElementAt(j);
                    string combination = word + item;

                    // Check if the combination forms a valid word
                    if (combination.Length == 6 && !output.Contains($"{word} + {item}={combination}") && word != item)
                    {
                        output.Add($"{word}+{item}={combination}");
                    }
                }
            }
        }

        [Benchmark]
        public void CalculateWithListParallelFor()
        {
            var words = _list.ToList();
            var output = new List<string>();
            Parallel.For(0, words.Count, i =>
            {
                Parallel.For(0, words.Count, j =>
                {
                    string combination = words.ElementAt(i) + words.ElementAt(j);

                    // Check if the combination forms a valid word
                    if (combination.Length == 6 && !output.Contains($"{words.ElementAt(i)}+{words.ElementAt(j)}={combination}") && i != j)
                    {
                        output.Add($"{words.ElementAt(i)}+{words.ElementAt(j)}={combination}");
                    }
                });
            });
        }
        [Benchmark]
        public void CalculateWithListParallelForEach()
        {
            var words = _list.ToList();
            var output = new List<string>();
            Parallel.ForEach(words, i =>
            {
                Parallel.ForEach(words, j =>
                {
                    string combination = i + j;

                    // Check if the combination forms a valid word
                    if (combination.Length == 6 && !output.Contains($"{i}+{j}={combination}") && i != j)
                    {
                        output.Add($"{i} + {j}={combination}");
                    }

                });
            });
        }

        [Benchmark]
        public void CalculateWithHashedListParallelForEach()
        {
            var words = _list.ToHashSet();
            var output = new List<string>();
            Parallel.ForEach(words, i =>
            {
                Parallel.ForEach(words, j =>
                {
                    string combination = i + j;

                    // Check if the combination forms a valid word
                    if (combination.Length == 6 && !output.Contains($"{i}+{j}={combination}") && i != j)
                    {
                        output.Add($"{i} + {j}={combination}");
                    }

                });
            });
        }

        [Benchmark]
        public void CalculateWithHashedListParallelFor()
        {
            var words = _list.ToHashSet();
            var output = new List<string>();
            Parallel.For(0, words.Count, i =>
            {
                Parallel.For(0, words.Count, j =>
                {
                    string combination = words.ElementAt(i) + words.ElementAt(j);

                    // Check if the combination forms a valid word
                    if (combination.Length == 6 && !output.Contains($"{words.ElementAt(i)}+{words.ElementAt(j)}={combination}") && i != j)
                    {
                        output.Add($"{words.ElementAt(i)}+{words.ElementAt(j)}={combination}");
                    }
                });
            });
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<CalculationBenchmark>(
                DefaultConfig.Instance.WithOption(ConfigOptions.JoinSummary, true)
                );
        }
    }

}