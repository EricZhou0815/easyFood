import {SET_FOOD} from '../actions/foodActionTypes'

const initialState = {
   foods:[]
  }
  
  export default (state = initialState, action) => {
    switch (action.type) {
        case SET_FOOD:
            return {
                ...state,
                foods: {...action.foods}
            }
        default:
            return state
    }
  }