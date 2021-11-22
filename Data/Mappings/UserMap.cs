using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users"); // NOME DA TABELA

            builder.HasKey(prop => prop.Id); // CHAVE PRIMARIA 

            builder.Property(prop => prop.Name)
                .HasConversion(prop => prop.ToString(), prop => prop) //CONVERSÂO GARANTIR QUE SEJA STRING
                .IsRequired() // NOT NULL
                .HasColumnName("Name") //NOME DA COLUNA
                .HasColumnType("varchar(100)"); //TAMANHO DA COLUNA

            builder.Property(prop => prop.Email)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Email")
               .HasColumnType("varchar(100)");


            builder.Property(prop => prop.Create)
               .IsRequired()
               .HasColumnName("Create")
               .HasDefaultValue(DateTime.Now); //ADICIONAR VALOR DEFAULT

        }
    }
}

