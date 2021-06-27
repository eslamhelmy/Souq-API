using Microsoft.EntityFrameworkCore.Migrations;

namespace Souq.Database.Migrations
{
    public partial class AddCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var columns = new string[] { "NameAr", "NameEn" };
            var tvValues = new string[] { "TV", "تليفزيون" };
            var laptopValues = new string[] { "Laptop", "لاب توب" };
            var soundSystempValues = new string[] { "Sound System", "انظمة صوت" };
            //migrationBuilder.InsertData(
            //       table: "Category",
            //       columns: new[] { "NameAr","NameEn" },
            //       values: new object[,]
            //       {
            //           { "TV", "تليفزيون" },
            //           { "Laptop", "لاب توب" },
            //           { "Sound System", "انظمة صوت" }

            // });
            //migrationBuilder.InsertData(table: "Category", columns, values: tvValues);
            //migrationBuilder.InsertData(table: "Category", columns, values: laptopValues);
            //migrationBuilder.InsertData(table: "Category", columns, values: soundSystempValues);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //var columns = new string[] { "NameAr", "NameEn" };
            //var tvValues = new string[] { "TV", "تليفزيون" };
            //var laptopValues = new string[] { "Laptop", "لاب توب" };
            //var soundSystempValues = new string[] { "Sound System", "انظمة صوت" };
            //migrationBuilder.DeleteData("Category", columns,tvValues);
            //migrationBuilder.DeleteData("Category", columns,laptopValues);
            //migrationBuilder.DeleteData("Category", columns,soundSystempValues);
        }
    }
}
