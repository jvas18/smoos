enum UserProfile {
    Common = 'Common',
    Admin = 'Admin',
  }

const allProfiles = (): any[] => [
    { value: UserProfile.Common, description: 'Normal' },
    { value: UserProfile.Admin, description: 'Administrador' },

  ];

export { UserProfile, allProfiles };
