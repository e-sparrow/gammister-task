using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Cards;
using Game.Cards.Enums;
using Game.Cards.Interfaces;
using Game.Combinations.Interfaces;
using Game.Deals.Interfaces;
using UnityEngine;
using Utils.Screens.Interfaces;
using Zenject;

namespace Game.Deals
{
    public class DealService : IDealService
    {
        public DealService
        (
            IDealConfiguration configuration,
            IDealSettings settings,
            IDealScreen screen, 
            IScreenService screenService,
            ICombinationProvider combinationProvider,
            IFactory<ICardView> cardViewFactory,
            ICardSpriteStorage cardSpriteStorage
        )
        {
            _configuration = configuration;
            _settings = settings;
            _screen = screen;
            _screenService = screenService;
            _combinationProvider = combinationProvider;
            _cardViewFactory = cardViewFactory;
            _cardSpriteStorage = cardSpriteStorage;
        }

        private readonly IDealConfiguration _configuration;
        private readonly IDealSettings _settings;
        
        private readonly IDealScreen _screen;
        private readonly IScreenService _screenService;
        
        private readonly ICombinationProvider _combinationProvider;
        private readonly IFactory<ICardView> _cardViewFactory;
        private readonly ICardSpriteStorage _cardSpriteStorage;

        private readonly IDictionary<ICardView, ICard> _cards = new Dictionary<ICardView, ICard>();
        
        private IList<ICard> _deck = new List<ICard>();
        
        private int _switchedTimes = 0;
        
        public async Task<IDealResult> Deal(int bet)
        {
            _screenService.ShowScreen(_screen);
            
            _screen.Reset();
            
            InitializeDeck();
            InitializeViews();
            
            _screen.SetSwitches(_settings.SwitchesCount - _switchedTimes);

            await _screen.WaitForApply();

            var result = AnalyzeCombination();
            
            _screen.SetSwitches(0);
            _screen.SetCombination(result.Combination);

            await _screen.WaitForNext();
            
            return result;
            
            void InitializeDeck()
            {
                _switchedTimes = 0;
                
                _deck.Clear();
                for (var suit = 0; suit < 4; suit++)
                {
                    for (var rank = 1; rank < 14; rank++)
                    {
                        var card = new Card((ECardSuit) suit, (ECardRank) rank);
                        _deck.Add(card);
                    }
                }

                _deck = _deck
                    .OrderBy(_ => Random.value)
                    .ToList();
            }

            void InitializeViews()
            {
                foreach (var card in _cards.Keys)
                {
                    card.Dispose();
                }
                
                _cards.Clear();
                
                for (var i = 0; i < _settings.CardCount; i++)
                {
                    var view = _cardViewFactory.Create();
                    
                    var card = _deck.Last();
                    _deck.Remove(card);

                    var sprite = _cardSpriteStorage.GetSprite(card);
                    
                    view.SetSprite(sprite);
                    _cards.Add(view, card);

                    view.OnClick += Switch;

                    void Switch()
                    {
                        if (_settings.SwitchesCount > _switchedTimes)
                        {
                            var newCard = _deck.Last();
                            _deck.Remove(newCard);

                            var previousCard = _cards[view];
                            var randomIndex = Random.Range(0, _deck.Count);
                            _deck.Insert(randomIndex, previousCard);
                            
                            _cards[view] = newCard;
                            
                            var newView = _cardSpriteStorage.GetSprite(newCard);
                            view.SetSprite(newView);
                            
                            _switchedTimes++;
                            _screen.SetSwitches(_settings.SwitchesCount - _switchedTimes);
                        }
                    }
                }
            }

            IDealResult AnalyzeCombination()
            {
                var dictionary = _cards.ToDictionary(value => value.Value, value => value.Key);
                var cards = _cards.Values;

                var isCombination = _combinationProvider.Check(cards, out var type, out var combination);
                if (isCombination)
                {
                    foreach (var card in combination)
                    {
                        dictionary[card].SetHighlighted(true);
                    }

                    var multiplier = _configuration.GetCombinationMultiplier(type);

                    var dealResult = new DealResult(true, type, multiplier);
                    return dealResult;
                }
                else
                {
                    var dealResult = new DealResult();
                    return dealResult;
                }
            }
        }
    }
}