using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Vic3MapMaker.DataFiles;

namespace Vic3MapMaker
{


    public class MapOperation {
        public Stack<Action> UndoStack { get; } = new Stack<Action>();
        public int StackSize { get; set; } = 0;
        Random rand = new Random();

        //move prov to another state 
        public void MoveProvince(State fromState, State toState, Province prov, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => MoveProvince(toState, fromState, prov, false));
            }
            fromState.provDict.Remove(prov.color);
            toState.provDict.Add(prov.color, prov);

            //if prov has any hubs clear the hubs
            if (prov.hubList.Count > 0) {
                foreach (string hub in prov.hubList) {
                    ClearHub(fromState, prov, hub);
                }
            }

        }
        //move prov to another nation singular
        public void MoveProvince(Nation fromNation, Nation toNation, Province prov, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => MoveProvince(toNation, fromNation, prov, false));
            }
            try {
                fromNation.provDict.Remove(prov.color);
                toNation.provDict.Add(prov.color, prov);
            }
            catch {

            }
        }
        //move prov to another nation multiple
        public void MoveProvince(Nation fromNation, Nation toNation, List<Province> provList, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => MoveProvince(toNation, fromNation, provList, false));
            }
            foreach (Province prov in provList) {
                try {
                    fromNation.provDict.Remove(prov.color);
                    toNation.provDict.Add(prov.color, prov);
                }
                catch {

                }
            }
        }

        //add prov
        public void AddProvince(State state, Province prov, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => RemoveProvince(state, prov, false));
            }
            state.provDict.Add(prov.color, prov);
        }
        public void AddProvince(Nation nation, Province prov, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => RemoveProvince(nation, prov, false));
            }
            nation.provDict.Add(prov.color, prov);
        }
        //remove prov
        public void RemoveProvince(State state, Province prov, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => AddProvince(state, prov, false));
            }
            state.provDict.Remove(prov.color);
        }
        public void RemoveProvince(Nation nation, Province prov, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => AddProvince(nation, prov, false));
            }
            nation.provDict.Remove(prov.color);
        }

        //move state to another region
        public void MoveState(Region fromRegion, Region toRegion, State state, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => MoveState(toRegion, fromRegion, state, false));
            }
            fromRegion.states.Remove(state);
            toRegion.states.Add(state);
        }

        //toggles primeland status of a province
        public void TogglePrimeland(Province prov, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => TogglePrimeland(prov, false));
            }
            prov.isPrimeLand = !prov.isPrimeLand;
        }
        //toggles impassible status of a province
        public void ToggleImpassable(Province prov, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => ToggleImpassable(prov, false));
            }
            prov.isImpassible = !prov.isImpassible;
        }
        //change prov terrain
        public void ChangeTerrain(Province prov, string terrain, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => ChangeTerrain(prov, prov.terrain, false));
            }
            prov.terrain = terrain;
        }
        //change state naval exit
        public bool ChangeStateNavalID(State state, int navalStateID, bool navalProvIsSea, bool undoAble = true) {
            //return false if navalProv isSea is false
            if (!navalProvIsSea) {
                return false;
            }
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => ChangeStateNavalID(state, state.navalID, true, false));
            }
            //set state naval exit to navalState id
            state.navalID = navalStateID;
            return true;
        }
        //clear state naval exit
        public void ClearStateNavalID(State state, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => ChangeStateNavalID(state, state.navalID, true, false));
            }
            //set state naval exit to -1
            state.navalID = -1;
        }

        //set hub
        public bool SetHub(State state, Province prov, Province oldProv, string hubName, bool undoAble = true) {
            //if prov is outside of state, return false
            if (!state.provDict.ContainsKey(prov.color)) {
                Console.WriteLine("SetHub: prov is not in state (Key)");
                return false;
            }

            //if old prov is null
            if (oldProv == null) {
                if (undoAble) {
                    StackSize += 1;
                    UndoStack.Push(() => ClearHub(state, prov, hubName, false));
                }
                //set hub name
                prov.hubList.Add(hubName);
            }
            else {
                if (undoAble) {
                    StackSize += 1;
                    UndoStack.Push(() => SetHub(state, oldProv, prov, hubName, false));
                }
                //clear old hub name
                oldProv.hubList.Remove(hubName);
                //set new hub name
                prov.hubList.Add(hubName);
            }
            return true;
        }
        //clear hub
        public void ClearHub(State state, Province prov, string hubName, bool undoAble = true) {
            if (prov == null) {
                return;
            }
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => SetHub(state, prov, null, hubName, false));
            }
            //clear hub name
            prov.hubList.Remove(hubName);

        }
        //Add Resource
        public void AddResource(State state, Resource recouorce, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => RemoveResource(state, recouorce, false));
            }
            state.resources.Add(recouorce);
        }
        //Remove Resource
        public void RemoveResource(State state, Resource resource, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => AddResource(state, resource, false));
            }
            state.resources.Remove(resource);
        }
        //Update Resource
        public void UpdateResource(State state, Resource newResource, Resource oldResource, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => UpdateResource(state, oldResource, newResource, false));
            }
            state.resources.Remove(oldResource);
            state.resources.Add(newResource);
        }
        //Update State
        public void UpdateState(State state, string name, int arableLand, string subsistenceBuilding, List<string> traits, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => UpdateState(state, state.name, state.arableLand, state.subsistenceBuilding, state.traits, false));
            }
            state.name = name;
            state.arableLand = arableLand;
            state.subsistenceBuilding = subsistenceBuilding;
            state.traits = traits;
            //if color is not set, set it
            if (state.color.A == 0) {
                //random color
                state.color = Color.FromArgb(255, rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            }

        }
        //Add State
        public void AddState(Region region, State state, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => RemoveState(region, state, false));
            }
            region.states.Add(state);
        }
        //Remove State
        public void RemoveState(Region region, State state, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => AddState(region, state, false));
            }
            region.states.Remove(state);
        }
        //change capital
        public bool ChangeCapital(Region region, Province prov, bool undoAble = true) {
            //if prov is outside of region, return false
            if (!region.states.Any(x => x.provDict.Values.Any(y => y == prov)) && prov != null) {
                Console.WriteLine("ChangeCapital: prov is not in region (Key)");
                return false;
            }
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => ChangeCapital(region, region.capital, false));
            }
            //set region capital to prov
            region.capital = prov;
            return true;

        }
        //update region
        public void UpdateRegion(Region region, string name, string gfxCulture, string superRegion, Color color, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => UpdateRegion(region, region.name, region.gfxCulture, region.superRegion, region.color, false));
            }
            region.name = name;
            region.gfxCulture = gfxCulture;
            region.superRegion = superRegion;
            region.color = color;
        }
        //add region
        public void AddRegion(Region region, HashSet<Region> regionSet, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => RemoveRegion(region, regionSet, false));
            }
            regionSet.Add(region);
        }
        //remove region
        public void RemoveRegion(Region region, HashSet<Region> regionSet, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => AddRegion(region, regionSet, false));
            }
            regionSet.Remove(region);
        }
        //add culutre homeland to state
        public void AddCulturalHomeLand(State state, string culture, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => RemoveCulturalHomeLand(state, culture, false));
            }
            state.homeLandList.Add(culture);
        }
        //remove culture homeland from state
        public void RemoveCulturalHomeLand(State state, string culture, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => AddCulturalHomeLand(state, culture, false));
            }
            state.homeLandList.Remove(culture);
        }
        //add claim to state
        public void AddClaim(State state, string claim, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => RemoveClaim(state, claim, false));
            }
            state.claimList.Add(claim);
        }
        //remove claim from state
        public void RemoveClaim(State state, string claim, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => AddClaim(state, claim, false));
            }
            state.claimList.Remove(claim);
        }

        //add pop
        public void AddPop(SubState state, Pop pop, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => RemovePop(state, pop, false));
            }
            state.pops.Add(pop);
        }
        //remove pop
        public void RemovePop(SubState state, Pop pop, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => AddPop(state, pop, false));
            }
            state.pops.Remove(pop);
        }
        //update pop
        public void UpdatePop(SubState state, Pop newPop, Pop oldPop, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => UpdatePop(state, oldPop, newPop, false));
            }
            state.pops.Remove(oldPop);
            state.pops.Add(newPop);
        }
        //update substate type
        public void UpdateSubStateType(SubState state, string type, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => UpdateSubStateType(state, state.type, false));
            }
            state.type = type;
        }
        //update nation
        public void UpdateNation(Nation nation, string tag, string name, string adj, Color color, string tier, string type, string wealth, string literacy, State capital, bool isNamedFromCapital, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => UpdateNation(nation, nation.tag, nation.name, nation.adj, nation.color, nation.tier, nation.type, nation.wealth, nation.literacy, nation.capital, nation.isNamedFromCapital, false));
            }
            nation.tag = tag;
            nation.name = name;
            nation.adj = adj;
            nation.color = color;
            nation.tier = tier;
            nation.type = type;
            nation.wealth = wealth;
            nation.literacy = literacy;
            nation.capital = capital;
            nation.isNamedFromCapital = isNamedFromCapital;
        }
        //add nation
        public void AddNation(HashSet<Nation> nationSet, Nation nation, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => RemoveNation(nationSet, nation, false));
            }
            nationSet.Add(nation);
        }
        //remove nation
        public void RemoveNation(HashSet<Nation> nationSet, Nation nation, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => AddNation(nationSet, nation, false));
            }
            nationSet.Remove(nation);
        }
        //add nation culture
        public void AddNationCulture(Nation nation, string culture, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => RemoveNationCulture(nation, culture, false));
            }
            nation.cultures.Add(culture);
        }
        //remove nation culture
        public void RemoveNationCulture(Nation nation, string culture, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => AddNationCulture(nation, culture, false));
            }
            nation.cultures.Remove(culture);
        }

        //add trade route
        public void AddTradeRoute(Nation nation, TradeRoute tradeRoute, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => RemoveTradeRoute(nation, tradeRoute, false));
            }
            nation.tradeRoutes.Add(tradeRoute);
        }
        //remove trade route
        public void RemoveTradeRoute(Nation nation, TradeRoute tradeRoute, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => AddTradeRoute(nation, tradeRoute, false));
            }
            nation.tradeRoutes.Remove(tradeRoute);
        }
        //update trade route
        public void UpdateTradeRoute(TradeRoute newRoute, TradeRoute oldRoute, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => UpdateTradeRoute(oldRoute, newRoute, false));
            }

            oldRoute.target = newRoute.target;
            oldRoute.goods = newRoute.goods;
            oldRoute.isExport = newRoute.isExport;
            oldRoute.level = newRoute.level;

        }

        //merge SubStates
        public void MergeSubStates(Nation maninNation, SubState mainSubState, Nation subNation, SubState subState, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => SplitSubStates(maninNation, mainSubState, subNation, subState, false));
            }
            //remove substate from subnation
            subNation.subStates.Remove(subState);
            //go through all pops in subState and check if there is a pop in mainSubState with the same culture, religion and type
            foreach (Pop pop in subState.pops) {
                bool found = false;
                foreach (Pop mainPop in mainSubState.pops) {
                    if (mainPop.culture == pop.culture && mainPop.religion == pop.religion && mainPop.type == pop.type) {
                        //if there is a pop with the same culture, religion and type, add the size of the pop to the mainPop
                        mainPop.size += pop.size;
                        found = true;
                        break;
                    }
                }
                //if there is no pop with the same culture, religion and type, add the pop to the mainSubState
                if (!found) {
                    mainSubState.pops.Add(pop);
                }
            }
            //go throu all StateBuilding in subState and check if there is a building in mainSubState with the same building type
            foreach (StateBuilding building in subState.buildings) {
                bool found = false;
                foreach (StateBuilding mainBuilding in mainSubState.buildings) {
                    if (mainBuilding.building == building.building) {
                        //if there is a building with the same type, add the level of the building to the mainBuilding
                        mainBuilding.level += building.level;
                        found = true;
                        break;
                    }
                }
                //if there is no building with the same type, add the building to the mainSubState
                if (!found) {
                    mainSubState.buildings.Add(building);
                }
            }



        }

        //split SubStates (reverses mergeSubStates)
        private void SplitSubStates(Nation maninNation, SubState mainSubState, Nation subNation, SubState subState, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => MergeSubStates(maninNation, mainSubState, subNation, subState, false));
            }
            //add substate to subnation
            subNation.subStates.Add(subState);
            //go through all pops in mainSubState and check if there is a pop in subState with the same culture, religion and type and reduce the size of the pop in mainSubState by the size of the pop in subState
            foreach (Pop pop in mainSubState.pops) {
                foreach (Pop subPop in subState.pops) {
                    if (subPop.culture == pop.culture && subPop.religion == pop.religion && subPop.type == pop.type) {
                        pop.size -= subPop.size;
                        //if the size of the pop in mainSubState is 0, remove the pop from mainSubState
                        if (pop.size == 0) {
                            mainSubState.pops.Remove(pop);
                        }
                        break;
                    }
                }
            }
            //go throu all StateBuilding in mainSubState and check if there is a building in subState with the same building type and reduce the level of the building in mainSubState by the level of the building in subState
            foreach (StateBuilding building in mainSubState.buildings) {
                foreach (StateBuilding subBuilding in subState.buildings) {
                    if (subBuilding.building == building.building) {
                        building.level -= subBuilding.level;
                        //if the level of the building in mainSubState is 0, remove the building from mainSubState
                        if (building.level == 0) {
                            mainSubState.buildings.Remove(building);
                        }
                        break;
                    }
                }
            }
        }

        //merge SubStates multi
        public void MergeSubStates(Nation mainNation, List<SubState> mainSubStates, Nation subNation, List<SubState> subStates, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                //UndoStack.Push(() => SplitSubStates(mainNation, mainSubStates, subNation, subStates, false));
            }
            //remove substates from subnation
            foreach (SubState subState in subStates) {
                subNation.subStates.Remove(subState);
            }
            //go through all substats and match them with the mainSubStates on the same parrentState
            for (int i = 0; i < subStates.Count; i++) {
                SubState subState = subStates[i];
                SubState mainSubState = mainSubStates[i];
                //go through all pops in subState and check if there is a pop in mainSubState with the same culture, religion and type
                foreach (Pop pop in subState.pops) {
                    bool found = false;
                    foreach (Pop mainPop in mainSubState.pops) {
                        if (mainPop.culture == pop.culture && mainPop.religion == pop.religion && mainPop.type == pop.type) {
                            //if there is a pop with the same culture, religion and type, add the size of the pop to the mainPop
                            mainPop.size += pop.size;
                            found = true;
                            break;
                        }
                    }
                    //if there is no pop with the same culture, religion and type, add the pop to the mainSubState
                    if (!found) {
                        mainSubState.pops.Add(pop);
                    }
                }
                //go throu all StateBuilding in subState and check if there is a building in mainSubState with the same building type
                foreach (StateBuilding building in subState.buildings) {
                    bool found = false;
                    foreach (StateBuilding mainBuilding in mainSubState.buildings) {
                        if (mainBuilding.building == building.building) {
                            //if there is a building with the same type, add the level of the building to the mainBuilding
                            mainBuilding.level += building.level;
                            found = true;
                            break;
                        }
                    }
                    //if there is no building with the same type, add the building to the mainSubState
                    if (!found) {
                        mainSubState.buildings.Add(building);
                    }
                }
            }

        }
        //split SubStates multi (reverses mergeSubStates multi)
        private void SplitSubStates(Nation mainNation, List<SubState> mainSubStates, Nation subNation, List<SubState> subStates, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => MergeSubStates(mainNation, mainSubStates, subNation, subStates, false));
            }
            //add substates to subnation
            foreach (SubState subState in subStates) {
                subNation.subStates.Add(subState);
            }
            //go through all substats and match them with the mainSubStates on the same parrentState
            for (int i = 0; i < subStates.Count; i++) {
                SubState subState = subStates[i];
                SubState mainSubState = mainSubStates[i];
                //go through all pops in mainSubState and check if there is a pop in subState with the same culture, religion and type and reduce the size of the pop in mainSubState by the size of the pop in subState
                foreach (Pop pop in mainSubState.pops) {
                    foreach (Pop subPop in subState.pops) {
                        if (subPop.culture == pop.culture && subPop.religion == pop.religion && subPop.type == pop.type) {
                            pop.size -= subPop.size;
                            //if the size of the pop in mainSubState is 0, remove the pop from mainSubState
                            if (pop.size == 0) {
                                mainSubState.pops.Remove(pop);
                            }
                            break;
                        }
                    }
                }
                //go throu all StateBuilding in mainSubState and check if there is a building in subState with the same building type and reduce the level of the building in mainSubState by the level of the building in subState
                foreach (StateBuilding building in mainSubState.buildings) {
                    foreach (StateBuilding subBuilding in subState.buildings) {
                        if (subBuilding.building == building.building) {
                            building.level -= subBuilding.level;
                            //if the level of the building in mainSubState is 0, remove the building from mainSubState
                            if (building.level == 0) {
                                mainSubState.buildings.Remove(building);
                            }
                            break;
                        }
                    }
                }
            }
        }

        //update production Method for StateBuilding
        public void UpdateProducitonMethond(StateBuilding stateBuilding, string newMethond, string oldMethond, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => UpdateProducitonMethond(stateBuilding, oldMethond, newMethond, false));
            }
            //find and replace oldMethond in stateBuilding.activeProductionMethods with newMethond
            //if oldMethond is not in stateBuilding.activeProductionMethods, add newMethond to stateBuilding.activeProductionMethods
            if (stateBuilding.activeProductionMethods.Contains(oldMethond) && oldMethond != "") {
                stateBuilding.activeProductionMethods.Remove(oldMethond);
            }
            //if newMethond is null return
            if (newMethond == "") return;
            stateBuilding.activeProductionMethods.Add(newMethond);

        }

        //update StateBuilding
        public void UpdateStateBuilding(StateBuilding StateBuilding, Building building, int level, int reserves, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => UpdateStateBuilding(StateBuilding, StateBuilding.building, StateBuilding.level, StateBuilding.reserves, false));
            }
            StateBuilding.building = building;
            StateBuilding.level = level;
            StateBuilding.reserves = reserves;
        }

        //add StateBuilding
        public void AddStateBuilding(SubState subState, StateBuilding stateBuilding, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => RemoveStateBuilding(subState, stateBuilding, false));
            }
            //add stateBuilding to subState
            subState.buildings.Add(stateBuilding);
        }

        //remove StateBuilding
        public void RemoveStateBuilding(SubState subState, StateBuilding stateBuilding, bool undoAble = true) {
            if (undoAble) {
                StackSize += 1;
                UndoStack.Push(() => AddStateBuilding(subState, stateBuilding, false));
            }
            //remove stateBuilding from subState
            subState.buildings.Remove(stateBuilding);
        }

        //undo last action
        public string Undo() {
            if (UndoStack.Count > 0) {
                Action action = UndoStack.Pop();
                string actionName = action.Method.Name.Split('>')[0].Replace("<", "");
                action();
                StackSize -= 1;
                Console.WriteLine("Undo: " + actionName);
                return actionName;
            }
            return "None";
        }
        //undo last n actions
        public string Undo(int amount) {
            string actionName = "None";
            for (int i = 0; i < amount; i++) {
                actionName = Undo();
            }
            return actionName;
        }
    }
}
