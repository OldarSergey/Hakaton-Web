import Card from 'react-bootstrap/Card';
import ModalShow from './ModalShow';
import Button from 'react-bootstrap/esm/Button';
import React from 'react';


const Project =(props) =>{

    const [modalShow, setModalShow] = React.useState(false);


    return(
        <Card>
        <Card.Header>{props.name}</Card.Header>
        <Card.Body>
                
                <Card>
                    <Card.Body>
                        <>
                            <Button variant="secondary" onClick={() => setModalShow(true)}>
                                Launch vertically centered modal
                            </Button>
                        
                            <ModalShow title={props.name}
                                show={modalShow}
                                onHide={() => setModalShow(false)}
                            />
                        </>
                    </Card.Body>
                </Card>
        </Card.Body>
      </Card>
      
    )
}

export default Project;