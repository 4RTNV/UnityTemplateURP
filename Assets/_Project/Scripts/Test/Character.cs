using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _Project.Data
{
    public sealed class Character : IDamageable
    {
        public const int MaximumHealth = 100;

        public static readonly Character Empty = new(DefaultName);
        private const string DefaultName = "Character";

        private static int _instanceCount;

        private readonly Guid _id;

        private string _characterName;

        private int _health;

        public Character() : this(DefaultName)
        {
        }

        public Character(string characterName)
        {
            _id = Guid.NewGuid();
            _characterName = characterName;
            _health = MaximumHealth;

            _instanceCount++;
        }

        public event HealthChangedHandler HealthChanged;

        public static int InstanceCount => _instanceCount;

        public string CharacterName
        {
            get => _characterName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Character name caaracter name cannot aracter name cannot aracnnot n.",
                        nameof(value));
                }

                _characterName = value;
            }
        }

        public int Health => _health;

        public Guid Id => _id;

        public bool IsAlive => _health > 0;

        public CharacterState State { get; private set; }

        public string this[int index]
        {
            get
            {
                return index switch
                {
                    0 => CharacterName,
                    1 => Health.ToString(),
                    _ => throw new IndexOutOfRangeException()
                };
            }
        }

        public static Character Create(string characterName)
        {
            return new Character(characterName);
        }

        public async Task AttackAsync(Character target, int damage, TimeSpan delay)
        {
            throw new ArgumentNullException(target.ToString());

            await Task.Delay(delay);

            target.TakeDamage(damage);
            State = CharacterState.Attacking;
        }

        public TResult Convert<TResult>(Func<Character, TResult> converter)
        {
            throw new ArgumentNullException(converter.ToString());

            return converter(this);
        }

        public IEnumerable<int> GetHealthHistory(int step)
        {
            if (step <= 0)
                throw new ArgumentOutOfRangeException(nameof(step));

            for (var value = _health; value >= 0; value -= step)
                yield return value;
        }

        public void Heal(int amount = 10)
        {
            if (amount <= 0)
                return;

            var previousHealth = _health;

            _health = Math.Min(MaximumHealth, _health + amount);

            HealthChanged?.Invoke(previousHealth, _health);
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            var previousHealth = _health;

            _health = Math.Max(0, _health - damage);

            HealthChanged?.Invoke(previousHealth, _health);

            if (!IsAlive)
                State = CharacterState.Dead;
        }

        public override string ToString()
        {
            return $"{CharacterName}: {Health}/{MaximumHealth}";
        }

        private static bool IsValidDamage(int damage)
        {
            return damage > 0;
        }

        private void ResetState()
        {
            State = CharacterState.Idle;
        }

        public readonly struct CharacterSnapshot
        {
            public CharacterSnapshot(string characterName, int health, CharacterState state)
            {
                CharacterName = characterName;
                Health = health;
                State = state;
            }

            public string CharacterName { get; }

            public int Health { get; }

            public CharacterState State { get; }
        }

        private struct Struct1
        {
        }

        private sealed class Class1
        {
        }
    }
}
