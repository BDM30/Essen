using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Essen.Models;

namespace Essen.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta8-15964")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Essen.Models.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryID");
                });

            modelBuilder.Entity("Essen.Models.Entities.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("CategoryID");

                    b.Property<int>("ImportanceLevel");

                    b.Property<int>("RecipeID");

                    b.Property<int>("ReplaceabilityLevel");

                    b.HasKey("IngredientID");
                });

            modelBuilder.Entity("Essen.Models.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmountDefault");

                    b.Property<int>("CategoryID");

                    b.Property<string>("Name");

                    b.Property<int>("UnitMeasureID");

                    b.HasKey("ProductID");
                });

            modelBuilder.Entity("Essen.Models.Entities.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ProcessDescription");

                    b.HasKey("RecipeID");
                });

            modelBuilder.Entity("Essen.Models.Entities.UnitMeasure", b =>
                {
                    b.Property<int>("UnitMeasureID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("UnitMeasureID");
                });

            modelBuilder.Entity("Essen.Models.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("UserID");
                });

            modelBuilder.Entity("Essen.Models.Entities.UserProduct", b =>
                {
                    b.Property<int>("UserProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("CategoryID");

                    b.Property<string>("ExpirationDate");

                    b.Property<int>("ProductID");

                    b.Property<int>("UserID");

                    b.HasKey("UserProductID");
                });
        }
    }
}
