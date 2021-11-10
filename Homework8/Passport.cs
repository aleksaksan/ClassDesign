using System;
 

namespace Homework8
{
    class Passport
    {
        int _serial;
        int _number;
        string _issued;
        DateTime _issuedDate;
        bool _isActive;
        public int Serial
        {
            get { return _serial; }
            set
            {
                if (value >= 1000 && value < 10000)
                    _serial = value;
                else
                    throw new ArgumentException("серия паспорта должна состоять из 4 символов!");
            }
        }
        public int Number
        {
            get
            { return _number; }
            set
            {
                if (value >= 100000 && value < 1000000)
                    _number = value;
                else
                    throw new ArgumentException("серия паспорта должна состоять из 6 символов!");
            }
        }
        public string Issued
        {
            get { return _issued; }
            set
            {
                if (value != "")
                    _issued = value;
                else
                    throw new ArgumentException("Информация о выдаче документа не заполнена!");
            }
        }

        public DateTime IssuedDate
        {
            get
            {
                return _issuedDate;
            }
            set
            {
                if (value > new DateTime(1991, 12, 25) && value < DateTime.Today)
                    _issuedDate = value;
                else
                    throw new ArgumentException("неверная дата выдачи документа");
            }
        }
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
    }
}
