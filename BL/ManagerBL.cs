using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DAL;
using Persistence;

namespace BL {
    public class ManagerBL {
        public Manager Login (String email, String password) {
            ManagerDAL mandal = new ManagerDAL ();
            string regexEmail = @"^[^<>()[\]\\,;:'\%#^\s@\$&!@]+@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z0-9]+\.)+[a-zA-Z]{2,}))$";
            string regexPassword = @"^[-.@_a-zA-Z0-9 ]+$";
            if (Regex.IsMatch (email, regexEmail) != true || email == "" || Regex.IsMatch (password, regexPassword) != true || password == "") {
                return null;
            }
            return mandal.Login (email, password);
        }
    }
}