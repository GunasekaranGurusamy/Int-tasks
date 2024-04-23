using Int_tasks.DTO;

namespace Int_tasks
{
    public class Linq
    {
        #region Add-Data
        IList<Student> studentList = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", Age = 13, StandardID =1 },
                    new Student() { StudentID = 2, StudentName = "Moin",  Age = 21, StandardID =1 },
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID =2 },
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID =2 },
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 15, StandardID =2 },
        };

        IList<Standard> standardList = new List<Standard>() {
                    new Standard(){ StandardID = 1, StandardName="Standard 1"},
                    new Standard(){ StandardID = 2, StandardName="Standard 2"},
                    new Standard(){ StandardID = 3, StandardName="Standard 3"} };
        #endregion 

        public void getstandardcount()
        {
            var Result = (from sd in standardList
                          join s in studentList on sd.StandardID equals s.StandardID
                          group sd by sd.StandardName into grp
                          select new { StandardName = grp.Key, Count = grp.Count() });

            foreach (var x in Result) { Console.WriteLine("Name:{0}  Count:{1}", x.StandardName, x.Count); }
        }

        public void getstudentdetails()
        {
            var groupJoin = from std in standardList
                            join s in studentList
                            on std.StandardID equals s.StandardID into studentGroup
                            select new { Students = studentGroup, StandardName = std.StandardName };

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.StandardName);
                foreach (var stud in item.Students) { Console.WriteLine(stud.StudentName); }
            }
        }

        public async void queryexec()
        {
            //groupjoin or leftjoin

            var groupJoin = from std in standardList
                            join s in studentList
                            on std.StandardID equals s.StandardID into studentGroup
                            from s in studentGroup.DefaultIfEmpty()
                            select new { Students = studentGroup, StandardName = std.StandardName };

            var groupcountQuery = (from std in standardList
                                   join s in studentList
                                   on std.StandardID equals s.StandardID
                                   group std by std.StandardName into grp
                                   select new { StandardName = grp.Key, Count = grp.Count() });

            foreach (var item in groupcountQuery) { Console.WriteLine("Name: {0}  Count:{1}", item.StandardName, item.Count); }
            

            //inner join
            var linqQuery = (from std in standardList
                             join s in studentList
                             on std.StandardID equals s.StandardID
                             select new { StudentName = s.StudentName, StandardName = std.StandardName });

            var output = linqQuery.ToList();

            var groups = linqQuery.GroupBy(n => n.StudentName).Select(n => new { MetricName = n.Key, MetricCount = n.Count() }).OrderBy(n => n.MetricName);

            var output3 = linqQuery.GroupBy(x => x.StandardName).Take(10).ToList();

            //var output4 = linqQuery.GroupBy(x => x.StandardName).Skip(countOnoutput1 - 1).Take(1).ToList();

            var output5Asc = linqQuery.OrderBy(X => X.StudentName).ToList();
            var output6Desc = linqQuery.OrderByDescending(X => X.StudentName).ToList();

            //var linqQuery2 = (from techer in _appContext.TblShipments
            //                  join student in _appContext.TblBookings on techer.ShpId equals student.ShpId
            //                  where techer.ShpId == 1
            //                  select new
            //                  {
            //                      StudentId = student.BokId
            //                  });

            //var MAX = await linqQuery2.MaxAsync();

            //var MIN = await linqQuery2.MinAsync();

        }
    }
}
