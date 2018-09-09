using Credit.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Credit.Rest.DataContract
{
    [DataContract]
    public class DebtorDataMember
    {
        private Debtor _entity;

        public DebtorDataMember() {
            _entity = new Debtor();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

        public Debtor Entity {
            get
            {
                if (_entity == null)
                {
                    _entity = new Debtor();
                }

                _entity.Name = Name;
                _entity.Id = Id;
                _entity.Email = Email;
                _entity.Phone = Phone;

                return _entity;
            }
        }

        public static DebtorDataMember ConvertFromEntity(Debtor debtor) {
            DebtorDataMember dataMember = new DebtorDataMember() {
                Id = debtor.Id,
                Name = debtor.Name,
                Email = debtor.Email,
                Phone = debtor.Phone
            };

            return dataMember;
        }

        public static IEnumerable<DebtorDataMember> ConvertFromEntityList(IEnumerable<Debtor> debtorList)
        {
            var dataMemberList = new List<DebtorDataMember>();

            foreach (Debtor d in debtorList) {
                dataMemberList.Add(
                    ConvertFromEntity(d)
                );
            }

            return dataMemberList;
        }
    }
}