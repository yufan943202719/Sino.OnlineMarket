using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sino.OnlineMarket.Repositories.Repository;
using Sino.OnlineMarket.Repositories.ViewModel;
using Sino.OnlineMarket.Webhost.ViewModel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sino.OnlineMarket.Webhost.Controllers
{
    [Route("sino/[controller]")]
    public class Uservalues : Controller
    {
        UsersRepository information = new UsersRepository();

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<UserInfoResponse> Register([FromBody]Users body)
        {
            UserInfoResponse response = new UserInfoResponse();
            UsersRepository u = new UsersRepository();
            if (u.CheckUsersByName(body.UserName) >0)
            {
                response.ReplyMsg = "用户已存在";
                return response;
            }
            else if (body.UserName == "")
            {
                response.ReplyMsg = "用户名不能为空";
                return response;
            }
            else if (body.UserPassword == "")
            {
                response.ReplyMsg = "用户密码不能为空";
                return response;
            }
            else if (body.Sex == "")
            {
                response.ReplyMsg = "请输入您的性别";
                return response;
            }
            else if (body.PhoneNum == "")
            {
                response.ReplyMsg = "请输入您的电话号码";
                return response;
            }
            else if (body.Address == "")
            {
                response.ReplyMsg = "请输入您的收件地址";
                return response;
            }
            else if (body.PostalCode== "")
            {
                response.ReplyMsg = "请输入您的邮政编码";
                return response;
            }
            else
            {
                Users user = new Users
                {
                    UserId = body.UserId,
                    UserName = body.UserName,
                    UserPassword = body.UserPassword,
                    Sex = body.Sex,
                    Address = body.Address,
                    PhoneNum = body.PhoneNum,
                    PostalCode = body.PostalCode
                };
                var count = await u.AddUsers(user);
                if(count>0)
                {
                    response.ReplyMsg = "注册成功";
                }
                else
                {
                    response.ReplyMsg = "注册失败";
                }
                return response;
            }
        }


        /// <summary>
        /// 获取单个用户信息
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        [HttpGet("GetUserInfo")]
        public async Task<UserInfoList> GetUserInfo(int UserId)
        {
            Users u = new Users();
            UserInfoList response = new UserInfoList();
            if (UserId != 0)
            {
                u = await information.GetUserById(UserId);
            }
            response.UserId = u.UserId;
            response.UserName = u.UserName;
            response.Sex = u.Sex;
            response.PhoneNum = u.PhoneNum;
            response.PostalCode = u.PostalCode;
            response.Address = u.Address;
            return response;
        }


        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost("AlterUserInfo")]
        public async Task<UserInfoResponse> AlterUserInfo([FromBody]Users body)
        {
            UserInfoResponse response = new UserInfoResponse();
            if (body.UserId == 0)
            {
                response.ReplyMsg = "用户ID不能为空！";
                return response;
            }
            else if (body.UserName == "")
            {
                response.ReplyMsg = "请填写您的用户名";
                return response;
            }
            else if (body.Sex == "")
            {
                response.ReplyMsg = "请填写您的性别";
                return response;
            }
            else if (body.PhoneNum == "")
            {
                response.ReplyMsg = "请填写您的电话号码";
                return response;
            }
            else if (body.Address == "")
            {
                response.ReplyMsg = "请填写您的收件地址";
                return response;
            }
            else if (body.PostalCode == "")
            {
                response.ReplyMsg = "请填写您的邮政编码";
                return response;
            }
            else
            {
               
                var count = await information.AlterUserInfo(body);
                if (count > 0)
                {
                    response.ReplyMsg = "用户信息编辑成功";
                }
                else if (count == -1)
                {
                    response.ReplyMsg = "尚未修改任何信息";
                }
                else
                {
                    response.ReplyMsg = "用户信息编辑失败";
                }
                return response;
            }
        }
    }
    }

