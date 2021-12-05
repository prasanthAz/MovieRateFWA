using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieRating.Repository.Entities;

namespace MovieRating.Repository.EntityTypeConfigurations
{
    public class MovieRatingConfiguration : IEntityTypeConfiguration<MovieRatings>
    {
        public void Configure(EntityTypeBuilder<MovieRatings> builder)
        {
            builder.ToTable("MovieRating");

            builder.HasKey(pk => new { pk.MovieId, pk.UserId });

            builder.HasOne(fk => fk.Movie)
                .WithMany(fk => fk.MovieRatings)
                .HasForeignKey(fk => fk.MovieId);

            builder.HasOne(fk => fk.User)
                .WithMany(fk => fk.MovieRatings)
                .HasForeignKey(fk => fk.UserId);
        }
    }
}
