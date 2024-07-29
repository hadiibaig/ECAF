using ECAF.INFRASTRUCTURE.Config;
using ECAF.INFRASTRUCTURE.Models;
using ECAF.INFRASTRUCTURE.utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Repositories
{
    public class SettingRepository
    {
        private readonly ECAFEntities _db;
        public SettingRepository()
        {
            _db = new ECAFEntities();
        }
        public List<string> GetRoleNames()
        {
            return _db.AspNetRoles.Where(r => r.Name != "Admin").Select(x => x.Name).ToList();
        }

        public SettingsViewModel GetSettingPageModels()
        {
            var roles = GetRoleNames();
            var forms = _db.Forms.ToList();
            var users = _db.AspNetRoles.Where(x => x.Name == RoleNames.AccountManager)?.Select(y => y.AspNetUsers)?.SelectMany(t => t);
            var managers = users.Any() ? users.ToList() : null;
            return new SettingsViewModel() { Roles = roles, Forms = forms, Users = managers };

        }
        public SubmitQuestions GetQuestions(long FormId)
        {
            var form = _db.Forms.FirstOrDefault(x => x.FormId == FormId);
            var questions = _db.Questions.Where(x => x.FormId == FormId);
            if(questions != null && questions.Count() > 0)
            {
                return new SubmitQuestions() { Questions = questions.Select(x => x.Text).ToList(), UserId = form.AssignedUser };
            }
            else
            {
                return new SubmitQuestions();
            }
        }
        public bool SaveUsersQuestions(SubmitQuestions model, string userId)
        {
            if (model.Questions.Any())
            {
                using (DbContextTransaction transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        var form = _db.Forms.FirstOrDefault(x => x.FormId == model.FormId);
                        var existingQustions = _db.Questions.Where(x => x.FormId == model.FormId);
                        if (existingQustions != null && existingQustions.Count() > 0)
                        {
                            _db.Questions.RemoveRange(existingQustions);
                            _db.SaveChanges();
                        }
                        foreach (var item in model.Questions)
                        {
                            Question question = new Question()
                            {
                                Text = item,
                                CreatorId = userId,
                                FormId = model.FormId,
                                AssignedUserId = model.UserId
                            };
                            _db.Questions.Add(question);
                            _db.SaveChanges();
                        }

                        form.AssignedUser = model.UserId;
                        form.AssignedToMe = true;
                        _db.SaveChanges();
                        transaction.Commit();
                        var user = _db.AspNetUsers.FirstOrDefault(x => x.Id == model.UserId);
                        var formDesc = _db.Forms.FirstOrDefault(x => x.FormId == model.FormId)?.Description;
                        EmailService.SendEmail(user.Email, "You have been assigned questions in ECAF", "Questions have been assigned to you in ECAF for form " + formDesc);
                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return false;
                    }

                }
            }
            else
            {
                return false;
            }

            //if (model.UserQuestions.Any())
            //{
            //    using (DbContextTransaction transaction = _db.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            foreach (var item in model.UserQuestions)
            //            {
            //                Question question = new Question()
            //                {
            //                    Text = item.Question,
            //                    CreatorId = userId,
            //                    FormId = model.FormId
            //                };
            //                _db.Questions.Add(question);
            //                _db.SaveChanges();

            //                List<UserQuestion> listUserQuestions = item.UserIds.Select(x => new UserQuestion() { UserId = x, QuestionId = question.Id }).ToList();
            //                //item.UserIds.ForEach(x => _db.UserQuestions.Add(new UserQuestion() { UserId = x, QuestionId = question.Id }));
            //                _db.UserQuestions.AddRange(listUserQuestions);
            //                _db.SaveChanges();
            //            }
            //            transaction.Commit();
            //            var userIds = model.UserQuestions.Select(x => x.UserIds).SelectMany(t => t).Distinct();
            //            var users = _db.AspNetUsers.Where(x => userIds.Contains(x.Id));
            //            var formDesc = _db.Forms.FirstOrDefault(x => x.FormId == model.FormId)?.Description;
            //            if(users.Count() > 0)
            //            {
            //                users.ToList().ForEach(x => EmailService.SendEmail( x.Email, "You have been assigned questions in ECAF", "Questions have been assigned to you in ECAF for form " + formDesc));
            //            }
            //            return true;
            //        }
            //        catch (Exception e)
            //        {
            //            transaction.Rollback();
            //            return false;
            //        }

            //    }
            //}
            //else
            //{
            //    return false;
            //}

        }
    }
}
