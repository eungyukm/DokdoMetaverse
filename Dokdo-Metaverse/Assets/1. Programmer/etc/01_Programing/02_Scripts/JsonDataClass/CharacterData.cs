﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    
    public class CharacterData
    {
        
        public int id;
        
        public string nick_name_value;
        
        public int gender_value;
        
        public int hat_id;
        
        public int hat_color_id;
        
        public int glasses_id;
        
        public int glasses_color_id;
        
        public int hair_id;
        
        public int hair_color_id;
        
        public int clothes_id;
        
        public int clothes_color_id;

        public CharacterData()
        {
            this.id = 3000;
            this.nick_name_value = "";
            this.gender_value = 0;
            this.hat_id = 8000;
            this.hat_color_id = 8500;
            this.glasses_id = 6000;
            this.glasses_color_id = 6500;
            this.hair_id = 7000;
            this.hair_color_id = 7500;
            this.clothes_id = 4000;
            this.clothes_color_id = 4500;
        }

        public CharacterData(int id, string nick_name_value, int gender_value, int hat_id, int hat_color_id,
            int glasses_id, int glasses_color_id, int hair_id, int hair_color_id, int clothes_id, int clothes_color_id)
        {
            this.id = id;
            this.nick_name_value = nick_name_value;
            this.gender_value = gender_value;
            this.hat_id = hat_id;
            this.hat_color_id = hat_color_id;
            this.glasses_id = glasses_id;
            this.glasses_color_id = glasses_color_id;
            this.hair_id = hair_id;
            this.hair_color_id = hair_color_id;
            this.clothes_id = clothes_id;
            this.clothes_color_id = clothes_color_id;
        }
    }
}