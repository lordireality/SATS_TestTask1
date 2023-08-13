using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATS_TestTask
{
    /// <summary>
    /// Магический класс
    /// </summary>
    public class PseudoClass
    {
        public List<Security.Models.User> SystemUsers = new List<Security.Models.User>();
        public List<Security.Models.OrganizationItem> SystemPosition = new List<Security.Models.OrganizationItem>();
        private Random random = new Random();
        /// <summary>
        /// Получить случайного пользователя
        /// </summary>
        /// <returns>Пользователь</returns>
        public Security.Models.User GetRandomUser()
        {
            
            return this.SystemUsers[this.random.Next(this.SystemUsers.Count)];
        }

        /// <summary>
        /// Получить список случайных пользователей случайной длинны
        /// </summary>
        /// <returns></returns>
        public List<Security.Models.User> GetRandomUsersList()
        {
            var prepList = new List<Security.Models.User>();
            for(int i = 0; i< this.SystemUsers.Count; i++)
            {
                prepList.Add(this.SystemUsers[this.random.Next(this.SystemUsers.Count)]);
            }
            return prepList.Distinct().ToList();
        }

        public PseudoClass()
        {
            _getBaseUsers().ForEach(c => SystemUsers.Add(c));
            _getBaseOrganizationItem().ForEach(c => SystemPosition.Add(c));
        }
        /// <summary>
        /// Генерирует пользователей
        /// </summary>
        /// <returns></returns>
        private List<Security.Models.User> _getBaseUsers()
        {
            var baseUsers = new List<Security.Models.User>();
            baseUsers.Add(new Security.Models.User { Id = 1, Uid = System.Guid.NewGuid(), Login = "admin", LastName = "Администратор", FirstName = "Системы" });
            baseUsers.Add(new Security.Models.User { Id = 2, Uid = System.Guid.NewGuid(), Login = "gendir", LastName = "Андреев", FirstName = "Андрей", MiddleName = "Андреевич" });
            baseUsers.Add(new Security.Models.User { Id = 3, Uid = System.Guid.NewGuid(), Login = "kurzamtb", LastName = "Иванов", FirstName = "Иван", MiddleName = "Иванович" });
            baseUsers.Add(new Security.Models.User { Id = 4, Uid = System.Guid.NewGuid(), Login = "kurzammb", LastName = "Петрова", FirstName = "Александра", MiddleName = "Александровна" });

            baseUsers.Add(new Security.Models.User { Id = 5, Uid = System.Guid.NewGuid(), Login = "nach_ois", LastName = "Александров", FirstName = "Александр", MiddleName = "Александрович" });
            baseUsers.Add(new Security.Models.User { Id = 6, Uid = System.Guid.NewGuid(), Login = "dev1", LastName = "Попелышева", FirstName = "Анастасия", MiddleName = "Игоревна" });
            baseUsers.Add(new Security.Models.User { Id = 7, Uid = System.Guid.NewGuid(), Login = "dev2", LastName = "Романов", FirstName = "Александр", MiddleName = "Михайлович" });

            baseUsers.Add(new Security.Models.User { Id = 8, Uid = System.Guid.NewGuid(), Login = "nach_manage", LastName = "Романов", FirstName = "Александр", MiddleName = "Михайлович" });
            baseUsers.Add(new Security.Models.User { Id = 9, Uid = System.Guid.NewGuid(), Login = "manage1", LastName = "Романов", FirstName = "Александр", MiddleName = "Михайлович" });
            baseUsers.Add(new Security.Models.User { Id = 10, Uid = System.Guid.NewGuid(), Login = "manage2", LastName = "Петрова", FirstName = "Александра", MiddleName = "Александровна" });

            return baseUsers;
        }

        /// <summary>
        /// Генерирует должности
        /// </summary>
        /// <returns></returns>
        public List<Security.Models.OrganizationItem> _getBaseOrganizationItem()
        {
            var baseOrgItem = new List<Security.Models.OrganizationItem>();
            
            baseOrgItem.Add(new Security.Models.OrganizationItem() { Id = 1, orgItemType = Security.Types.OrganizationItemType.Position, Uid = System.Guid.NewGuid(), Parent = null, Name = "Директор", User = this.SystemUsers.First(c => c.Login == "gendir") });
            baseOrgItem.Add(new Security.Models.OrganizationItem() { Id = 2, orgItemType = Security.Types.OrganizationItemType.Position, Uid = System.Guid.NewGuid(), Parent = 1, Name = "Заместитель директора по тех. управлению", User = this.SystemUsers.First(c => c.Login == "kurzamtb")  });
            baseOrgItem.Add(new Security.Models.OrganizationItem() { Id = 3, orgItemType = Security.Types.OrganizationItemType.Position, Uid = System.Guid.NewGuid(), Parent = 1, Name = "Заместитель директора по качеству", User = this.SystemUsers.First(c => c.Login == "kurzammb") });

            baseOrgItem.Add(new Security.Models.OrganizationItem() { Id = 4, orgItemType = Security.Types.OrganizationItemType.Department, Uid = System.Guid.NewGuid(), Parent = 2, Name = "Отдел Информационных Систем" });
            
            //5
            baseOrgItem.Add(new Security.Models.OrganizationItem() { Id = 6, orgItemType = Security.Types.OrganizationItemType.Position, Uid = System.Guid.NewGuid(), Parent = 4, Name = "Начальник Отдела Информационных Систем", User = this.SystemUsers.First(c => c.Login == "nach_ois") });
            //6 and 7
            baseOrgItem.Add(new Security.Models.OrganizationItem() { Id = 7, orgItemType = Security.Types.OrganizationItemType.Position, Uid = System.Guid.NewGuid(), Parent = 6, Name = "Программист", User = this.SystemUsers.First(c => c.Login == "dev1") });
            baseOrgItem.Add(new Security.Models.OrganizationItem() { Id = 8, orgItemType = Security.Types.OrganizationItemType.Position, Uid = System.Guid.NewGuid(), Parent = 6, Name = "Аналитик", User = this.SystemUsers.First(c => c.Login == "dev2") });
            

            baseOrgItem.Add(new Security.Models.OrganizationItem() { Id = 5, orgItemType = Security.Types.OrganizationItemType.Department, Uid = System.Guid.NewGuid(), Parent = 3, Name = "Отдел Качества" });
            baseOrgItem.Add(new Security.Models.OrganizationItem() { Id = 9, orgItemType = Security.Types.OrganizationItemType.Position, Uid = System.Guid.NewGuid(), Parent = 4, Name = "Начальник Отдела Качества", User = this.SystemUsers.First(c => c.Login == "nach_manage") });
            //id 8
            baseOrgItem.Add(new Security.Models.OrganizationItem() { Id = 10, orgItemType = Security.Types.OrganizationItemType.Position, Uid = System.Guid.NewGuid(), Parent = 4, Name = "Работник Отдела Качества", Users = this.SystemUsers.Where(c=>c.Login == "manage2" || c.Login == "manage1").ToList() });
            //id 9
            //id 10
            return baseOrgItem;
        }


    }
}
