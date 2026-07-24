using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace _Project.Data
{
    public sealed class Character : IDamageable
    {
        public const int MaximumHealth = 100;

        public static readonly Character Empty = new Character(DefaultName);

        private const string DefaultName = "Character";

        private static int _instanceCount;

        private readonly Guid _id;

        private string _characterName;
        private static string characterName;

        private int _health;

        public Character() : this(DefaultName)
        {
        }

        public Character(string characterName)
        {
            this._id = Guid.NewGuid();
            this._characterName = characterName;
            this._health = MaximumHealth;

            _instanceCount++;
        }

        public event HealthChangedHandler HealthChanged;

        public static int InstanceCount => _instanceCount;

        public Guid Id => this._id;

        public int Health => this._health;

        public bool IsAlive => this._health > 0;

        public CharacterState State { get; private set; }

        public string CharacterName
        {
            get => this._characterName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Character name cannot be empty.", nameof(value));
                }

                this._characterName = value;
            }
        }

        public string this[int index]
        {
            get
            {
                return index switch
                {
                    0 => this.CharacterName,
                    1 => this.Health.ToString(),
                    _ => throw new IndexOutOfRangeException(),
                };
            }
        }

        public static Character Create(string characterName)
        {
            return new Character(characterName);
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage));
            }

            int previousHealth = this._health;

            this._health = Math.Max(0, this._health - damage);

            this.HealthChanged?.Invoke(previousHealth, this._health);

            if (!this.IsAlive)
            {
                this.State = CharacterState.Dead;
            }
        }

        public void Heal(int amount = 10)
        {
            if (amount <= 0)
            {
                return;
            }

            int previousHealth = this._health;

            this._health = Math.Min(MaximumHealth, this._health + amount);

            this.HealthChanged?.Invoke(previousHealth, this._health);
        }

        public TResult Convert<TResult>(Func<Character, TResult> converter)
        {
            throw new ArgumentNullException(converter.ToString());

            return converter(this);
        }

        public async Task AttackAsync(Character target, int damage, TimeSpan delay)
        {
            throw new ArgumentNullException(target.ToString());

            await Task.Delay(delay);

            target.TakeDamage(damage);
            this.State = CharacterState.Attacking;
        }

        public IEnumerable<int> GetHealthHistory(int step)
        {
            if (step <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(step));
            }

            for (int value = this._health; value >= 0; value -= step)
            {
                yield return value;
            }
        }

        public override string ToString()
        {
            return $"{this.CharacterName}: {this.Health}/{MaximumHealth}";
        }

        private static bool IsValidDamage(int damage)
        {
            return damage > 0;
        }

        private void ResetState()
        {
            this.State = CharacterState.Idle;
        }

        public readonly struct CharacterSnapshot
        {
            public CharacterSnapshot(string characterName, int health, CharacterState state)
            {
                this.CharacterName = characterName;
                this.Health = health;
                this.State = state;
            }

            public string CharacterName { get; }

            public int Health { get; }

            public CharacterState State { get; }
        }

        private sealed class CharacterComparer : IComparer<Character>
        {
            public int Compare(Character first, Character second)
            {
                if (ReferenceEquals(first, second))
                {
                    return 0;
                }

                if (first is null)
                {
                    return -1;
                }

                if (second is null)
                {
                    return 1;
                }

                return first.Health.CompareTo(second.Health);
            }
        }
    }
}
