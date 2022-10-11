namespace CA221006_2
{
    internal class Fish
    {
        private float _weight;
        private bool _isWeightSet = false;
        private bool _predator;
        private int _swimTop;
        private int _swimDepth;
        private string _species;

        public float Weight
        {
            get => _weight;
            set
            {
                if (value < .5f)
                    throw new Exception("egy hal súlya nem lehet kevesebb, mint 0.5 Kg");
                if (value > 40f)
                    throw new Exception("egy hal súlya nem lehet több, mint 40 Kg");
                if (_isWeightSet && (value > _weight * 1.1f || value < _weight * .9f))
                    throw new Exception("egy hal súlya maximum 10%-al változhat!");
                else _isWeightSet = true;

                _weight = value;
            }
        }
        public bool Predator
        {
            get => _predator;
            private set => _predator = value;
        }
        public int SwimTop
        {
            get => _swimTop;
            set
            {
                if (value < 0 || value > 400)
                    throw new Exception("a maximális úszási magasság csak [0; 400]cm között valid!");

                _swimTop = value;
            }
        }
        public int SwimDepth
        {
            get => _swimDepth;
            set
            {
                if (value < 10 || value > 400)
                    throw new Exception("A merülési mélység csak [10, 400]cm között valid");
                _swimDepth = value;
            }
        }
        public int SwimBotm => SwimTop + SwimDepth;

        public string Species
        {
            get => _species;
            set
            {
                if (value is null)
                    throw new Exception("a halfajta nem lehet null");
                if (value.Length < 3 || value.Length > 30)
                    throw new Exception("a halfajta nevének hossza [3, 30] belül valid");

                _species = value;
            }
        }

        public string GetFishInfo()
        {
            return
                $"{Species,-8} " +
                $"{(Predator ? "(R)" : "(N)")} " +
                $"{Weight,5:0.00}Kg " +
                $"[{SwimTop,3}-{SwimBotm,3}]cm";
        }

        public Fish(float weight, bool predator, int swimTop, int swimDepth, string species)
        {
            Weight = weight;
            Predator = predator;
            SwimTop = swimTop;
            SwimDepth = swimDepth;
            Species = species;
        }
    }
}
