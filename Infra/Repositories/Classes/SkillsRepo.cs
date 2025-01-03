using Core;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class SkillsRepo:GenericRepo<Skill>,ISkillsRepo
    {
        Context cntx;
        public SkillsRepo(Context cntx):base(cntx)
        {
            this.cntx = cntx;
        }

        public List<CheckBoxVM> GetSkills()
        {
            var res = from t in this.cntx.Skills
                      select new CheckBoxVM
                      {
                          Value = t.SkillId,
                          Text = t.SkillName,
                          IsSelected = false
                      };
            return res.ToList();
        }
    }
}
