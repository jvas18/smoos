enum SongGenre{
    Kpop = 'Kpop',
    Pop = 'Pop',
    MPB =  'MPB',
    Rap = 'Rap',
    HipHop = 'HipHop',
    Rock = 'Rock',
    Funk = 'Funk',
    Indie = 'Indie',
    Electronic = 'Electronic',
    Country = 'Country',
    Sertanejo = 'Sertanejo',
    Pagode = 'Pagode',
    Samba = 'Samba',
    Axe = 'Axe',
    Gospel = 'Gospel',
    Reggae = 'Reggae'
}

const allGenres = (): any[] => [
    { value: SongGenre.Pop, description: 'Pop' },
    { value: SongGenre.Kpop, description: 'Kpop' },
    { value: SongGenre.MPB, description: 'MPB' },
    { value: SongGenre.Rap, description: 'Rap' },
    { value: SongGenre.HipHop, description: 'HipHop' },
    { value: SongGenre.Rock, description: 'Rock' },
    { value: SongGenre.Funk, description: 'Funk' },
    { value: SongGenre.Indie, description: 'Indie' },
    { value: SongGenre.Electronic, description: 'Eletrônica' },
    { value: SongGenre.Country, description: 'Country' },
    { value: SongGenre.Sertanejo, description: 'Sertanejo' },
    { value: SongGenre.Pagode, description: 'Pagode' },
    { value: SongGenre.Samba, description: 'Samba' },
    { value: SongGenre.Axe, description: 'Axé' },
    { value: SongGenre.Gospel, description: 'Gospel' },
    { value: SongGenre.Reggae, description: 'Reggae' }
];

export {SongGenre, allGenres};

