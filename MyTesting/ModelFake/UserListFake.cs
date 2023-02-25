using MinimalApiSample.ModelsMysql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTesting.ModelFake
{
    public static  class UserListFake
    {

        public readonly static UserMysql user = new UserMysql()
        {
            Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
            Name = "Orange Juice",
            LastName = "Orange Tree"
        };

        public static List<UserMysql>  _UserMysql = new List<UserMysql> {

            new UserMysql() {
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Name = "Orange Juice", 
                LastName="Orange Tree"
            },
            new UserMysql() {
                Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                Name = "Diary Milk", 
                LastName="Cow"
            },
            new UserMysql() {
                Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                Name = "Frozen Pizza",
                LastName="Uncle Mickey"
            }
        };
               
    }
}
