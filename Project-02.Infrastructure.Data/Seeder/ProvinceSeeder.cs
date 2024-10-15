using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_02.Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02.Infrastructure.Data.Seeder
{
    public class ProvinceSeeder : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            var jsonProvince = 
                "[{\"ProvinceId\":1,\"ProvinceName\":\"آذربایجان شرقی\"}," +
                "{\"ProvinceId\":2,\"ProvinceName\":\"آذربایجان غربی\"}," +
                "{\"ProvinceId\":3,\"ProvinceName\":\"اردبیل\"}," +
                "{\"ProvinceId\":4,\"ProvinceName\":\"اصفهان\"}," +
                "{\"ProvinceId\":5,\"ProvinceName\":\"البرز\"}," +
                "{\"ProvinceId\":6,\"ProvinceName\":\"ایلام\"}," +
                "{\"ProvinceId\":7,\"ProvinceName\":\"بوشهر\"}," +
                "{\"ProvinceId\":8,\"ProvinceName\":\"تهران\"}," +
                "{\"ProvinceId\":9,\"ProvinceName\":\"چهارمحال وبختیاری\"}," +
                "{\"ProvinceId\":10,\"ProvinceName\":\"خراسان جنوبی\"}," +
                "{\"ProvinceId\":11,\"ProvinceName\":\"خراسان رضوی\"}," +
                "{\"ProvinceId\":12,\"ProvinceName\":\"خراسان شمالی\"}," +
                "{\"ProvinceId\":13,\"ProvinceName\":\"خوزستان\"}," +
                "{\"ProvinceId\":14,\"ProvinceName\":\"زنجان\"}," +
                "{\"ProvinceId\":15,\"ProvinceName\":\"سمنان\"}," +
                "{\"ProvinceId\":16,\"ProvinceName\":\"سیستان وبلوچستان\"}," +
                "{\"ProvinceId\":17,\"ProvinceName\":\"فارس\"}," +
                "{\"ProvinceId\":18,\"ProvinceName\":\"قزوین\"}," +
                "{\"ProvinceId\":19,\"ProvinceName\":\"قم\"}," +
                "{\"ProvinceId\":20,\"ProvinceName\":\"کردستان\"}," +
                "{\"ProvinceId\":21,\"ProvinceName\":\"کرمان\"}," +
                "{\"ProvinceId\":22,\"ProvinceName\":\"کرمانشاه\"}," +
                "{\"ProvinceId\":23,\"ProvinceName\":\"کهگیلویه وبویراحمد\"}," +
                "{\"ProvinceId\":24,\"ProvinceName\":\"گلستان\"}," +
                "{\"ProvinceId\":25,\"ProvinceName\":\"گیلان\"}," +
                "{\"ProvinceId\":26,\"ProvinceName\":\"لرستان\"}," +
                "{\"ProvinceId\":27,\"ProvinceName\":\"مازندران\"}," +
                "{\"ProvinceId\":28,\"ProvinceName\":\"مرکزی\"}," +
                "{\"ProvinceId\":29,\"ProvinceName\":\"هرمزگان\"}," +
                "{\"ProvinceId\":30,\"ProvinceName\":\"همدان\"}," +
                "{\"ProvinceId\":31,\"ProvinceName\":\"یزد\"}]";

            var provinces = JsonConvert.DeserializeObject<List<Province>>(jsonProvince);

            builder.HasData(provinces);
        }
    }
}
