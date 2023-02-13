import React, {useState} from 'react';
import styled,{css} from 'styled-components';
import EmailForm from 'Components/EmailForm';
import EmailHistory from 'Components/EmailHistory';

const Wrapper = styled.div`

`;

const Tabs = styled.div`
    width: 100%;
    height: 34px;
    margin-top: 20px;
    display: block;
    background: #F1F1F1;
`;

const Tab = styled.div`
    float: left;
    margin-left: 20px;
    width: 200px;
    padding-top: 5px;
    padding-bottom: 5px;

    ${props => props.$active && css`
        background: #D6EEEE;
    `}

    &:hover {
        cursor: pointer;
    }
}`;

const TabContent = styled.div`
    width: 100%;
    float: left;
    margin-left: 20px;
`;

const Home = () => {
const [activeTab, setActiveTab] = useState(0);
     
const renderActiveTab = () => {
    console.log('activetab')
    console.log(activeTab)
        switch (activeTab) {
            case 0:
                return <EmailForm />
            case 1:
                return <EmailHistory />
            default:
                break;
        }
}

return (
    <Wrapper>
        <Tabs>
            <Tab $active={activeTab == 0} onClick={() => setActiveTab(0)}>Email Form</Tab>
            <Tab $active={activeTab == 1} onClick={() => setActiveTab(1)}>Email History</Tab>
        </Tabs>
        <TabContent>
            {renderActiveTab()}
        </TabContent>
    </Wrapper>
)
}

export default Home;