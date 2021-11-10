using System;
 
namespace Homework8
{
    class Monster
    {
        readonly string _name;//(название монстра. Проверка: не пустая строка)
        //(тип монстра. Предусмотреть 8-10 типов: dragon, orc, undead, construct, demon, mutant, animal, и т.д.)
        public enum MonsterType { draon, orc, undead, construct, demon, mutant, animal, human, cat }; 
        int _hp; //(текущее здоровье. Проверка: 0 - 500, но не более MaxHP)
        int _maxHP; //(полное здоровье. Проверка: 0 - 500)
        int _minAttack; //(минимальная сила атаки.Проверка:  1-10)
        int _maxAttack; //(максимальная атаки. Проверка:  20-100)
        string _warCry; //(боевой клич :)
        string _dieCry; //(крик умирания :)
        public MonsterType _typeText; 
        public string TypeText 
        {
            get
            {
                return _typeText switch
                {
                    MonsterType.draon => "дракон",
                    MonsterType.orc => "орк",
                    MonsterType.undead => "нежить",
                    MonsterType.construct => "хрень",
                    MonsterType.mutant => "мутант",
                    MonsterType.animal => "зверь",
                    MonsterType.human => "гопник",
                    MonsterType.cat => "котик",
                    _ => throw new ArgumentException("неизвестный монстр"),
                };
            }
        }
        public int HP
        {
            get { return _hp; }
            private set
            {
                if (value <= _maxHP && value > 0)
                    _hp = value;
                else
                    throw new ArgumentException("невозможное количество hp");
            }
        }
        public int MaxHp
        {
            get { return _maxHP; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("здоровье должно быть больше 0");
                else if (value > 500)
                    throw new ArgumentException("здоровье должно быть меньше 500");
                else
                    _maxHP = value;
            }
        }
        public int MinAttack
        {
            get { return _minAttack; }
            set
            {
                if (value <= 10 && value > 0)
                    _minAttack = value;
                else
                    throw new ArgumentException("минимальная атака должна быть больше 0 и меньше 10");
            }
        }
        public int MaxAttack
        {
            get { return _maxAttack; }
            set
            {
                if (value <= 100 && value > 19)
                    _maxAttack = value;
                else
                    throw new ArgumentException("максимальная атака должна быть в пределах от 20 до 100");
            }
        }

        bool _isDie;
        public bool IsDie { get => _hp == 0 ? true : false; }

        public string GetInfo
        {
            get
            {
                string status = "жив";
                if (IsDie)
                    status = "мёртв";
                return $"{TypeText}: текущее здоровье: {HP}, максимальное здоровье: {MaxHp}\n" +
                    $"урон от {MinAttack} до {MaxAttack}\nстатус: {status}";
            }
        }
        #region ctor's
        public Monster()
        {
            Random rnd = new Random();

            _typeText = (MonsterType)rnd.Next(0, 9);
            MaxHp = rnd.Next(1, 501);
            HP = MaxHp;
            MaxAttack = rnd.Next(20, 101);
            MinAttack = rnd.Next(1, 11);
            _warCry = "";
            _dieCry = "";
        }
        public Monster(MonsterType monster)
        {
            _typeText = monster;
            Random rnd = new Random();
            MaxHp = rnd.Next(0, 501);
            HP = MaxHp;
            MaxAttack = rnd.Next(20, 101);
            MinAttack = rnd.Next(1, 11);
            _warCry = "";
            _dieCry = "";
        }
        public Monster(MonsterType monster, int maxHp) : this(monster)
        {
            Random rnd = new Random();
            MaxHp = maxHp;
            HP = MaxHp;
            MaxAttack = rnd.Next(20, 101);
            MinAttack = rnd.Next(1, 11);
            _warCry = "";
            _dieCry = "";
        }
        public Monster(MonsterType monster, int maxHp, int minAttak, int maxAttak) : this(monster, maxHp)
        {
            Random rnd = new Random();
            MaxHp = maxHp;
            HP = MaxHp;
            MaxAttack = maxAttak;
            MinAttack = minAttak;
            _warCry = "";
            _dieCry = "";
        }
        public Monster(MonsterType monster, int maxHp, int minAttak, int maxAttak, string warCry, string dieCry) 
            : this(monster, maxHp, minAttak, maxAttak)
        {
            Random rnd = new Random();
            MaxHp = maxHp;
            HP = MaxHp;
            MaxAttack = maxAttak;
            MinAttack = minAttak;
            _warCry = warCry;
            _dieCry = dieCry;
        }
        #endregion
        public int GetAttack(int bonus = 0)
        {
            Random rnd = new Random();
            return rnd.Next(MinAttack, MaxAttack + 1) + bonus;
        }
        public void Wounds(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                HP = 0;
                Console.WriteLine(_dieCry);
            }
        }
        void Heal()
        {
            HP = MaxHp;
        }
    }
}
