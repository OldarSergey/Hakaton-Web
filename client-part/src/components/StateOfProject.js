import Project from "./Project";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';


const StateOfProject =()=>{


    return(

    <Container>
      <Row>
        <Col> 
            <Project/>
            <Project/>
            <Project/>
        </Col>
      </Row>
    </Container>

    );
}

export default StateOfProject;