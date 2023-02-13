import React, {useState} from 'react';
import styled from 'styled-components';
import axios from 'axios';
import CancelModal from 'Components/CancelModal';

const Form = styled.div`
    float: left;
    margin-top: 20px;
`;

const Row = styled.div`
    margin-bottom: 10px;

    label {
        margin-right: 5px;
        float: left;
    }
`;

const Button = styled.input`
appearance: none;
  background-color: #2ea44f;
  border: 1px solid rgba(27, 31, 35, .15);
  border-radius: 6px;
  box-shadow: rgba(27, 31, 35, .1) 0 1px 0;
  box-sizing: border-box;
  color: #fff;
  cursor: pointer;
  display: inline-block;
  font-family: -apple-system,system-ui,"Segoe UI",Helvetica,Arial,sans-serif,"Apple Color Emoji","Segoe UI Emoji";
  font-size: 14px;
  font-weight: 600;
  line-height: 20px;
  padding: 6px 16px;
  position: relative;
  text-align: center;
  text-decoration: none;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  vertical-align: middle;
  white-space: nowrap;
  margin-right: 10px;

  &:focus:not(:focus-visible):not(.focus-visible) {
    box-shadow: none;
    outline: none;
  }

  &:hover {
    background-color: #2c974b;
  }

  &:focus {
    box-shadow: rgba(46, 164, 79, .4) 0 0 0 3px;
    outline: none;
  }

  &:disabled {
    background-color: #94d3a2;
    border-color: rgba(27, 31, 35, .1);
    color: rgba(255, 255, 255, .8);
    cursor: default;
  }
  &:active {
    background-color: #298e46;
    box-shadow: rgba(20, 70, 32, .2) 0 1px 0 inset;
  }
`;

const EmailForm = () => {
    const [showModal, setShowModal] = useState(false);
    const [emailFields, setEmailFields] = useState({
        from: '',
        to: '',
        cc: '',
        subject: '',
        importance: 0,
        content: ''
    });

    const handleSubmit = (e) => {
        const request = {
            from: e.currentTarget.elements.from.value,
            to: e.currentTarget.elements.to.value,
            subject: e.currentTarget.elements.subject.value,
            cc: e.currentTarget.elements.cc.value.split(/[;,]+/),
            importance: e.currentTarget.elements.importance.value,
            content: e.currentTarget.elements.content.value
        }
        debugger;
        axios.post('https://localhost:7062/notification/email', request)
    }

    const onClose = (val) => {
        setShowModal(false);
        
        if (val) {
            setEmailFields({
                from: '',
                to: '',
                cc: '',
                subject: '',
                importance: 0,
                content: ''
            })
        }       
    }

    const UpdateEmailFields = (name, value) => {
        setEmailFields(prevState => ({...prevState, [name]: value}));
    }

    return (
        <div>
            <Form>
                <form onSubmit={(e) => handleSubmit(e)}>
                    <Row>
                        <label htmlFor='from'>From:</label>
                        <input type='email' name='from' value={emailFields.from} onChange={(e) => UpdateEmailFields(e.target.name, e.target.value)} />
                    </Row>
                    <Row>
                        <label htmlFor='to'>To: </label>
                        <input type='email' name='to' value={emailFields.to} onChange={(e) =>  UpdateEmailFields(e.target.name, e.target.value)} />
                    </Row>
                    <Row>
                        <label htmlFor='cc'>CC:</label>
                        <input type='email' name='cc' multiple value={emailFields.cc} onChange={(e) =>  UpdateEmailFields(e.target.name, e.target.value)} />
                    </Row>
                    <Row>
                        <label htmlFor='subject'>Subject:</label>
                        <input type='text' name='subject' value={emailFields.subject} onChange={(e) =>  UpdateEmailFields(e.target.name, e.target.value)} />
                    </Row>
                    <Row>
                        <label htmlFor='Importance'>Importance:</label>
                        <select name='importance' value={emailFields.importance} onChange={(e) =>  UpdateEmailFields(e.target.name, e.target.value)} >
                            <option value="Low">Low</option>
                            <option value="Normal">Normal</option>
                            <option value="High">High</option>
                        </select>
                    </Row>
                    <Row>
                        <label htmlFor='Content'>Content:</label>
                        <textarea name='content' value={emailFields.content} onChange={(e) => UpdateEmailFields(e.target.name, e.target.value)}></textarea>
                    </Row>
                    <Row>
                        <Button type='submit' value='Send' />
                        <Button type='button' value='Cancel' onClick={() => setShowModal(true)} />
                    </Row>
                </form>            
            </Form>
            <CancelModal show={showModal} onClose={(val) => onClose(val)} />
        </div>
    )
}

export default EmailForm;