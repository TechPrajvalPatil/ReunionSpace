using Core;
using Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class CourseDetRepo:GenericRepo<MemberCourseDet>, ICourseDetRepo
    {
        Context cntx;
        public CourseDetRepo(Context cntx):base(cntx)
        {
            this.cntx = cntx;
        }
    }
}
