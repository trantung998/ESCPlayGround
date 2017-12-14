namespace Sources.Formular
{
    public static class CharacterFormulars
    {
        //todo : thick them gi thi them
        public static int CalculateDamage(int damage, int armor)
        {
            return (int) (damage - armor * 0.7f);
        }
    }
}