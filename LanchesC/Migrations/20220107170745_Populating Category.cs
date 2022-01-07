using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesC.Migrations
{
    public partial class PopulatingCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO public.\"Categorys\"(\"CategoryName\", \"Description\") " +
                "VALUES('Normal','Snack with industrial ingredients.')");

            migrationBuilder.Sql("INSERT INTO public.\"Categorys\"(\"CategoryName\", \"Description\") " +
                "VALUES('Natural','Snack with natual ingredients.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.\"Categorys\"");
        }
    }
}
