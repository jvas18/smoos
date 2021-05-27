enum Category{
    Movie = 'Movie',
    Album = 'Album',
    Song =  'Song',
    Book = 'Book'
}
const allCategories = (): any[] => [
    { value: Category.Movie, description: 'Filme' },
    { value: Category.Album, description: 'Álbum' },
    { value: Category.Song, description: 'Música' },
    { value: Category.Book, description: 'Livro' }
];

export {Category, allCategories};