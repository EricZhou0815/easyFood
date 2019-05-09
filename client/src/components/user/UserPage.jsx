import React,{Component} from 'react'
import {connect} from 'react-redux'
import {cacheJWT, clearJWT} from '../../redux/actions/userActions'

class UserPage extends Component{
  constructor(props){
    super(props)
    this.state={
      isLogin:false
    }
  }

  componentDidMount=async()=>{
    const jwt='fdsafsanbiafnvsafds'
    cacheJWT(jwt)
    clearJWT()
  }

  render(){
    return (
      <div className="user-page">
      User
    </div>
    )
  }
}

const actionCreators={
  cacheJWT,
  clearJWT
}

const mapStateToProps=state=>({
  user:state.user,
  isLogin:state.user.isLogin
})


export default connect(mapStateToProps,actionCreators)(UserPage);