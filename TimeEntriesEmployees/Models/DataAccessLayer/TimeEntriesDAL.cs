using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeEntriesEmployees.Models.DisplayClasses;
using TimeEntriesEmployees.Models.Entity;

namespace TimeEntriesEmployees.Models.DataAccessLayer
{
    public class TimeEntriesDAL
    {
        TimeEntriesEntities connection = new TimeEntriesEntities();
        public List<TimeEntriesViewModelDisplayClasses> GetAll()
        {
            
            List<TimeEntriesViewModelDisplayClasses> list = new List<TimeEntriesViewModelDisplayClasses>();
            var Tlist = (from te in connection.TimeEntriesViewModels
                         where te.IsActive == true 
                          select new TimeEntriesViewModelDisplayClasses
                          {
                              EmployeeID=te.EmployeeID,
                              FirstName=te.FirstName,
                              LastName=te.LastName,
                              EmailAddress=te.EmailAddress,
                              Date=te.Date,
                              Task=te.Task,
                              HoursWorked=te.HoursWorked,
                              Comment=te.Comment,
                              IsActive = true,
                              LastModifiedBy = te.LastModifiedBy,
                              LastModifiedOn = te.LastModifiedOn,

                          }).ToList();
            return Tlist;
        }

        public bool Save(TimeEntriesViewModel te)
        {
            bool res = false;
            try
            {
                if (te != null)
                {
                    te.IsActive = true;
                    te.LastModifiedOn = DateTime.Now;
                    te.LastModifiedBy = 1;
                    connection.TimeEntriesViewModels.Add(te);
                    connection.SaveChanges();
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            catch (Exception ex)
            {


            }
            return res;
        }

        public bool Delete(int id)
        {
            bool res = false;
            TimeEntriesViewModel Tm = new TimeEntriesViewModel();
            Tm = connection.TimeEntriesViewModels.Where(a => a.EmployeeID == id).FirstOrDefault();
            try
            {
                if (Tm != null)
                {
                    Tm.IsActive = false;
                    Tm.LastModifiedOn = DateTime.Now;
                    Tm.LastModifiedBy = 1;
                    connection.Entry(Tm).CurrentValues.SetValues(Tm);
                    connection.SaveChanges();
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            catch (Exception ex)
            {

                res = false;
            }
            return res;
        }
        public TimeEntriesViewModel GetId(int id)
        {
            TimeEntriesViewModel Tm = new TimeEntriesViewModel();
            Tm = connection.TimeEntriesViewModels.Where(a => a.EmployeeID == id).FirstOrDefault();
            return Tm;
        }

        public bool Update(TimeEntriesViewModel TEV)
        {
            bool res = false;
            TimeEntriesViewModel tm = new TimeEntriesViewModel();

            tm = connection.TimeEntriesViewModels.Where(a => a.EmployeeID == TEV.EmployeeID).FirstOrDefault();
            try
            {
                if (tm != null && TEV != null)
                {
                    TEV.IsActive = true;
                    TEV.LastModifiedBy = 1;
                    TEV.LastModifiedOn = DateTime.Now;
                    connection.Entry(tm).CurrentValues.SetValues(TEV);
                    connection.SaveChanges();
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            catch (Exception ex)
            {

                res = false;
            }
            return res;
        }

    }
}