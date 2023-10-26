import './HeaderLine.css'


const HeaderLine =()=>{
    return(
    <header style={{ display: 'flex', backgroundColor: '#424f5f' }}>
        <h3 style={{ marginLeft: '5%', marginTop: '1%' }}>Logo</h3>
        <div className="input-group mb-3" style={{ marginRight: '40%', marginLeft: '10%', marginTop: '1%', maxHeight: '30px' }}>
          <input type="text" style={{ backgroundColor: '#3c4655', border: 'none' }} className="form-control" placeholder="Search" aria-label="Recipient's username" aria-describedby="basic-addon2" />
          <div className="input-group-append">
            <button className="btn btn-outline" style={{ backgroundColor: '#3688fc', marginLeft: '10%' }} type="button">Search</button>
          </div>
        </div>
        <div></div>
 
    </header>
    )
}

export default HeaderLine;