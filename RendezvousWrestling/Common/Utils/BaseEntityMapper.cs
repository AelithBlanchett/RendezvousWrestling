using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendezvousWrestling.Common.Utils
{
    public class BaseEntityMapper<TFightingGame, TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TModifierParameters, TUser, TFeatureParameters>
    where TActionFactory : IActionFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFeature : BaseFeature<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFeatureFactory : IFeatureFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TUser : BaseUser<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFight : BaseFight<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFighterState : BaseFighterState<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TActiveAction : BaseActiveAction<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFeatureParameters : BaseFeatureParameter<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TAchievement : BaseAchievement<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TModifier : BaseModifier<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFighterStats : BaseFighterStats<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFightingGame : BaseFightingGame<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TModifierParameters : BaseModifierParameter<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TModifierParameters, TUser, TFeatureParameters>, new()
    where TEntityMapper : BaseEntityMapper<TFightingGame, TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TModifierParameters, TUser, TFeatureParameters>, new()
    {

        static MapperConfiguration _mapperConfiguration;
        static Mapper _mapper;

        public MapperConfiguration MapperConfig
        {
            get
            {
                if (_mapperConfiguration == null)
                {
                    _mapperConfiguration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<TModifier, TModifierParameters>().ReverseMap();
                        cfg.CreateMap<TFeature, TFeatureParameters>().ReverseMap();
                    });
                }
                return _mapperConfiguration;
            }
        }

        public Mapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    _mapper = new Mapper(MapperConfig);
                }
                return _mapper;
            }
        }
    }
}
