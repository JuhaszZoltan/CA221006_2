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
            private set
            {
                _predator = value;
            }
        }
        public int SwimTop
        {
            get => _swimTop;
            set
            {
                _swimTop = value;
            }
        }
        public int SwimDepth
        {
            get => _swimDepth;
            set
            {
                _swimDepth = value;
            }
        }
        public string Species
        {
            get => _species;
            set
            {
                _species = value;
            }
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
